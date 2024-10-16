using ASDP.FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASDP.FinalProject.DAL.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId);

            builder.HasMany(x=> x.CreatedSignPipelines)
                .WithOne(x=> x.CreatorEmployee)
                .HasForeignKey(x=> x.CreatorEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.PipelinesToSign)
                .WithOne(x => x.SignerEmployee)
                .HasForeignKey(x => x.SignerEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
