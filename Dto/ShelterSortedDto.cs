using EmergencyShelterReadinessSystemAPI.Enums;
using EmergencyShelterReadinessSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmergencyShelterReadinessSystemAPI.Dto
{
    public class ShelterSortedDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; }
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;  
        public string BuildingNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsPublic { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ShelterType ShelterType { get; set; }


    }
}
