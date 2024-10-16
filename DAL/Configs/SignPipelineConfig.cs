using ASDP.FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASDP.FinalProject.DAL.Configs
{
    public class SignPipelineConfig : IEntityTypeConfiguration<SignPipeline>
    {
        public void Configure(EntityTypeBuilder<SignPipeline> builder)
        {
            builder.HasOne(x=> x.CreatorEmployee)
                .WithMany(x=> x.CreatedSignPipelines)
                .HasForeignKey(x=> x.CreatorEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SignDocument)
                .WithOne(x => x.SignPipeline)
                .HasForeignKey<SignDocument>(x=> x.SignPipelineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x=> x.Signers)
                .WithOne(x=> x.SignPipeline)
                .HasForeignKey(x=> x.SignPipelineId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
