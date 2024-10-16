using ASDP.FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASDP.FinalProject.DAL.Configs
{
    public class SignerToPipelineConfig : IEntityTypeConfiguration<SignerToPipeline>
    {
        public void Configure(EntityTypeBuilder<SignerToPipeline> builder)
        {
            
        }
    }
}
