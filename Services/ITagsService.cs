namespace ASDP.FinalProject.Services
{
    public interface ITagsService
    {
        public Task<Stream> FillTags(Stream file, SignContext signContext);
    }
}
