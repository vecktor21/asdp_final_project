using System.ComponentModel.DataAnnotations;
using System.Resources;
using ASDP;
using ASDP.FinalProject;

namespace ASDP.FinalProject.Constants
{
    public enum SignPipelineStatus
    {
        [Display(Name = "Создано")]
        Created = 1,
        [Display(Name = "На подписании")]
        InProcess,
        [Display(Name = "Подписано тимлидом")]
        SignedByTeamlid,
        [Display(Name = "Подписано директором")]
        SignedByDirector,
        [Display(Name = "Подпись отклонена")]
        Rejected
    }
}
