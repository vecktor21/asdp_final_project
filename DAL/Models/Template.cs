using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public byte[] Content { get; set; } = null!;
        public DateTimeOffset IndexDate { get; set; }
        public TemplateCode TemplateCode { get; set; }
        public Template()
        {
            
        }
        public Template(byte[] content, TemplateCode templateCode)
        {
            Content = content;
            TemplateCode = templateCode;
        }
    }
}
