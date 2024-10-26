
using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class TeamLeadFIOTagReplaceer : ITagReplacer
    {
        public string Tag { get; } = Tags.TeamLeadFIO;

        public Task<string> FindTagValue(SignContext signContext)
        {
            var res = $"{signContext.teamlid.SurName} {signContext.teamlid.Name}";
            return Task.FromResult(res);
        }
    }
}
