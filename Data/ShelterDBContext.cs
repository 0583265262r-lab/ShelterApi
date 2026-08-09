using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EmergencyShelterReadinessSystemAPI.Data
{
    public class ShelterDBContext:DbContext
    {
        public ShelterDBContext(DbContextOptions<ShelterDBContext> options)
            : base(options)
        {
        }
        public DbSet<Area> Areas { get; set; } = null!;

        public DbSet<Shelter> shelters { get; set; } = null!;

        public DbSet<Inspection> inspections { get; set; } = null!;
    }
}
