using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using EmergencyShelterReadinessSystemAPI.Enums;

namespace EmergencyShelterReadinessSystemAPI.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        
        public int AreaId { get; set; }
        
        public Area Area { get; set; }
        [Required]
        [StringLength(200)]
        
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string BuildingNumber { get; set; } = string.Empty;

        [Range(1,10000)]
        public int Capacity { get; set; }
        [Required]
        public bool IsAccessible { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShelterType ShelterType { get; set; }

        public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();

    }
}
