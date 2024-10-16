using ASDP.FinalProject.DAL.Configs;
using ASDP.FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.DAL
{
    public class AdspContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
