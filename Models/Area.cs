using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmergencyShelterReadinessSystemAPI.Models
{
    [Index(nameof(AreaCode), IsUnique = true)]
    [Index(nameof(City),nameof(Neighborhood), IsUnique = true)]
    public class Area
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Neighborhood { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string AreaCode { get; set; } = string.Empty;

        [Range(1,5)]
       
        public int RiskLevel { get; set; }

        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

    }
}
