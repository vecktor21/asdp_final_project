using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class DateTagReplacer : ITagReplacer
    {
        public string Tag { get; } = Tags.TeamLeadFIO;

        public Task<string> FindTagValue(SignContext signContext)
        {
            var res = DateTime.Now.ToString("dd.MM.yyyy");
            return Task.FromResult(res);
        }
    }
}
