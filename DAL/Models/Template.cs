using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public byte[] Content { get; set; } = null!;
        public string ContentType { get; set; }
        public DateTime IndexDate { get; set; } = DateTime.UtcNow;
        public Template()
        {
            
        }
        public Template(byte[] content, string name, string contentType)
        {
            Content = content;
            Name = name;
            this.ContentType=contentType;
        }
    }
}
