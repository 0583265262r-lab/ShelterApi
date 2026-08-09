using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EmergencyShelterReadinessSystemAPI.Data
{
    public class ShelterDBContext : DbContext
    {
        public ShelterDBContext(DbContextOptions<ShelterDBContext> options)
            : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; } = null!;

        public DbSet<Shelter> Shelters { get; set; } = null!;

        public DbSet<Inspection> Inspections { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shelter>()
                .Property(s => s.ShelterType)
                .HasConversion<string>();
            modelBuilder.Entity<Shelter>()
                .HasOne(s => s.Area)
                .WithMany(a => a.Shelters)
                .HasForeignKey(s => s.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Inspection>()
                .HasOne(i => i.Shelter)
                .WithMany(s => s.Inspections)
                .HasForeignKey(i => i.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}

