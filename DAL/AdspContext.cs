using ASDP.FinalProject.DAL.Configs;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.SeedConstants;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.DAL
{
    public class AdspContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PositionPermission> PositionPermission { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SignDocument> SignDocuments{ get; set; }
        public DbSet<SignerToPipeline> SignerToPipeline { get; set; }
        public DbSet<SignPipeline> SignPipeline { get; set; }
        public DbSet<Template> Templates { get; set; }

        public AdspContext(DbContextOptions<AdspContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PositionConfig());
            modelBuilder.ApplyConfiguration(new SignPipelineConfig());
            modelBuilder.ApplyConfiguration(new SignerToPipelineConfig());
            modelBuilder.ApplyConfiguration(new PositionPermissionConfig());

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            var permissions = PermissionSeedConstants.All;

            modelBuilder.Entity<Permission>().HasData(permissions);

            var positions = PositionSeedConstants.All;

            modelBuilder.Entity<Position>().HasData(positions);
            modelBuilder.Entity<PositionPermission>().HasData(PositionSeedConstants.AllPermissionPositions);


        }
    }
}
