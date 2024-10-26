using ASDP.FinalProject.Constants;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.UseCases.Documents.Commands;
using ASDP.FinalProject.UseCases.Documents.Dtos;
using ASDP.FinalProject.UseCases.Documents.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace ASDP.FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITagsService _tagsService;

        public DocumentsController(IMediator mediator, IMapper mapper, ITagsService tagsService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tagsService = tagsService;
        }

        /// <summary>
        /// получить список доступных шаблонов
        /// </summary>
        /// <returns></returns>
        [HttpGet("loadTemplates")]
        [ProducesResponseType<List<TemplateResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplates()
        {
            var res = await _mediator.Send(new GetTemplatesQuery());
            return Ok(res);
        }


        /// <summary>
        /// добавить шаблон
        /// </summary>
        /// <param name="name">template name</param>
        /// <param name="file">load template</param>
        /// <returns></returns>
        [HttpPost("addTemplate")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddTemplate([FromForm] string name, IFormFile file)
        {
            byte[] data;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                data = ms.ToArray();
            }

            var res = await _mediator.Send(new AddTemplateRequest
            {
                Content = data,
                Name = name,
                ContentType = file.ContentType

            });
            return Ok();
        }

        /// <summary>
        /// скачать сформированный документ. Можно использовать с <a href=".../api/Documents/getDocument/{documentId}" target="_blank"> </a>чтобы сразу скачать документа
        /// </summary>
        /// <returns></returns>
        [HttpGet("getDocument/{documentId}")]
        [ProducesResponseType<FileContentResult>(StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetDocument(Guid documentId)
        {
            var document = await _mediator.Send(new GetDocumentQuery { DocumentId=documentId});

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = document.Name,
                Inline = false,
            };
            Response.Headers.Append("Content-Disposition", cd.ToString());

            return File(document.Content, "application/pdf");
        }

        /// <summary>
        /// скачать шаблон. Можно использовать с <a href=".../api/Documents/getTemplate/{templateId}" target="_blank"> </a> чтобы сразу скачать документ
        /// </summary>
        /// <returns></returns>
        [HttpGet("getTemplate/{templateId}")]
        [ProducesResponseType<FileContentResult>(StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetTemplate(Guid templateId)
        {
            var document = await _mediator.Send(new GetTemplateQuery { TemplateId= templateId });

            var extension = document.ContentType switch
            {
                "application/msword" => "doc",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => "docx",
                _=>"docx"
            };

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = $"{document.Name}.{extension}",
                Inline = false,
            };
            Response.Headers.Append("Content-Disposition", cd.ToString());

            return File(document.Content, document.ContentType);
        }

        [HttpPost("TestReplaceTags")]
        [ProducesResponseType<FileContentResult>(StatusCodes.Status200OK)]
        public async Task<FileContentResult> TestReplaceTags([FromForm]IFormFile file, [FromForm] int creatorEmployeeId, [FromForm] int directorId, [FromForm]int teamlidId)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var document = (MemoryStream)await _tagsService.FillTags(ms, new SignContext(creatorEmployeeId, teamlidId, directorId));
            var extension = "pdf";

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = $"{file.FileName.Substring(0, Math.Min(file.FileName.Length, 50))}.{extension}",
                Inline = false,
            };
            Response.Headers.Append("Content-Disposition", cd.ToString().Replace("\r\n", ""));
            return File(document.ToArray(), "application/pdf");
        }

        [HttpPost("generateDocument")]
        [ProducesResponseType<FileContentResult>(StatusCodes.Status200OK)]
        public async Task<FileContentResult> GenerateDocument([FromForm] Guid templateId, [FromForm] int creatorEmployeeId, [FromForm] int directorId, [FromForm] int teamlidId)
        {
            var document = await _mediator.Send(new GenerateSignDocumentCommand()
            {
                TemplateId = templateId,
                CreatorUserId = creatorEmployeeId,
                TeamleadId = teamlidId,
                DirectorId = directorId
            });

            if (Path.GetExtension(document.Name).Contains("doc"))
            {
                document.Name = Path.ChangeExtension(document.Name, ".pdf");
            }
            else if (string.IsNullOrEmpty(Path.GetExtension(document.Name)))
            {
                document.Name = Path.ChangeExtension(document.Name, ".pdf");
            }

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = $"{document.Name}",
                Inline = false,
            };
            Response.Headers.Append("Content-Disposition", cd.ToString().Replace("\r\n", ""));
            return File(document.Content, "application/pdf");
        }

        /// <summary>
        /// получить список доступных тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet("tags")]
        public IActionResult GetAllTags()
        {
            var res = Tags.AllTags();

            return new JsonResult(res);
        }
    }

}
