using ASDP.FinalProject.Exceptions;
using ASDP.FinalProject.Services.TagReplacers;
using CSharpFunctionalExtensions;
using System.Reflection;
using System.Text;
using System.IO;
using Xceed.Words.NET;
using Org.BouncyCastle.Crypto.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Syncfusion.DocIORenderer;

namespace ASDP.FinalProject.Services
{
    public record SignContext(int creatorEmployeeId, int teamlidId, int directorId);

    public class TagsService : ITagsService
    {

        private readonly IServiceProvider _serviceProvider;

        public TagsService(IServiceProvider serviceProvider)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            _serviceProvider = serviceProvider;
        }

        public async Task<Stream> FillTags(Stream file, SignContext signContext)
        {
            using (var document = DocX.Load(file))
            {
                var foundTags = ExtractTags(document);
                var tagReplacers = FindTagReplacers(foundTags);
                var replacedTagValues = await FindTagValues(tagReplacers, signContext);

                ReplaceTagsInDocument(document, replacedTagValues);
                var pdfStream = new MemoryStream();

                using (MemoryStream wordStream = new MemoryStream())
                {
                    // Save the modified document to a MemoryStream
                    document.SaveAs(wordStream);
                    wordStream.Seek(0, SeekOrigin.Begin);


                    WordDocument wordDocument = new WordDocument(wordStream, Syncfusion.DocIO.FormatType.Automatic);
                    //Instantiation of DocIORenderer for Word to PDF conversion.
                    DocIORenderer render = new DocIORenderer();
                    //Converts Word document into PDF document.
                    PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
                    //Releases all resources used by the Word document and DocIO Renderer objects.
                    render.Dispose();
                    wordDocument.Dispose();

                    //Save the document into stream.
                    pdfDocument.Save(pdfStream);
                    //Close the document.
                    pdfDocument.Close(true);


                }


                return pdfStream;
            }

        }

        private List<string> ExtractTags(DocX document)
        {
                List<string> foundTexts = new List<string>();

                // Iterate through all paragraphs in the document
                foreach (var paragraph in document.Paragraphs)
                {
                    var text = paragraph.Text;
                    int startIndex = 0;
                    while ((startIndex = text.IndexOf("{{", startIndex)) != -1)
                    {
                        int endIndex = text.IndexOf("}}", startIndex);
                        if (endIndex != -1)
                        {
                            string foundText = text.Substring(startIndex + 2, endIndex - startIndex - 2);
                            foundTexts.Add(foundText);
                            startIndex = endIndex + 2; // Move past the closing brackets
                        }
                        else
                        {
                            break; // No closing bracket found
                        }
                    }
                }

                return foundTexts.Distinct().ToList();

        }

        private Dictionary<string, ITagReplacer> FindTagReplacers(List<string> tags)
        {
            var replacerTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.IsAssignableTo(typeof(ITagReplacer)) && !x.IsAbstract && !x.IsInterface)
                .ToList();

            var res =new Dictionary<string, ITagReplacer>();

            foreach (var tag in tags)
            {
                var foundType = replacerTypes.FirstOrDefault(x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Any(a => 
                        string.Equals(((ITagReplacer?)Activator.CreateInstance(x, true))?.Tag, tag, StringComparison.InvariantCultureIgnoreCase)
                        ));

                if (foundType == null) continue;

                var replacer = (ITagReplacer) _serviceProvider.GetRequiredService(foundType);

                res.Add(tag, replacer);
            }
            return res;
        }

        private async Task<Dictionary<string,string>> FindTagValues(Dictionary<string, ITagReplacer> tagReplacers, SignContext signContext)
        {
            var res = new Dictionary<string, string>();
            foreach (var tagReplacer  in tagReplacers)
            {
                var replacedValue = await tagReplacer.Value.FindTagValue(signContext);
                if (string.IsNullOrEmpty(replacedValue)) throw new AsdpException(Result.Failure($"Не найдено значение для тега {tagReplacer.Key}"));
                res.Add(tagReplacer.Key, replacedValue);
            }

            return res;
        }

        private void ReplaceTagsInDocument(DocX document, Dictionary<string,string> tagValues)
        {
            foreach (var tagValue in tagValues)
            {
                foreach (var paragraph in document.Paragraphs)
                {
                    paragraph.ReplaceText($"{{{{{tagValue.Key}}}}}", tagValue.Value);
                }
            }

        }
    }
}
