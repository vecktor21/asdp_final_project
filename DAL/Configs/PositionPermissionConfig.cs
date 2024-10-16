using ASDP.FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASDP.FinalProject.DAL.Configs
{
    public class PositionPermissionConfig : IEntityTypeConfiguration<PositionPermission>
    {
        public void Configure(EntityTypeBuilder<PositionPermission> builder)
        {
            builder.ToTable("PositionPermission");

            builder.HasOne(x=>x.Permission)
                .WithMany()
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
