using Microsoft.EntityFrameworkCore;
using OOAPInlamningsuppgift2.Configurations;
using OOAPInlamningsuppgift2.Entities;
using System.Reflection;

namespace OOAPInlamningsuppgift2
{
    public class HusRumDbContext : DbContext
    {
        public HusRumDbContext(DbContextOptions<HusRumDbContext> options) : base(options)
        {
        }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new DoorConfig());
            modelbuilder.ApplyConfiguration(new EventConfig());
            modelbuilder.ApplyConfiguration(new LogConfig());
            modelbuilder.ApplyConfiguration(new TenantConfig());

            //foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            //base.OnModelCreating(modelbuilder);
            //modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
