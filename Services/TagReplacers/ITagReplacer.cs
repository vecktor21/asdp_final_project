namespace ASDP.FinalProject.Services.TagReplacers
{
    public interface ITagReplacer
    {
        public string Tag { get; }
        public Task<string> FindTagValue(SignContext signContext);
    }
}
