using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class Template
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public byte[] Content { get; set; } = null!;
        public DateTimeOffset IndexDate { get; set; }
        public Template()
        {
            
        }
        public Template(byte[] content, string name)
        {
            Content = content;
            Name = name;
        }
    }
}
