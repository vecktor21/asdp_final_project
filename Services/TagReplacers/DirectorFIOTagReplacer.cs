using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class DirectorFIOTagReplacer : ITagReplacer
    {
        public string Tag { get; } = Tags.DirectorFIO;

        public Task<string> FindTagValue(SignContext signContext)
        {
            var res = $"{signContext.director.SurName} {signContext.director.Name}";
            return Task.FromResult(res);
        }
    }
}
