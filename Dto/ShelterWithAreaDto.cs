using EmergencyShelterReadinessSystemAPI.Enums;
using EmergencyShelterReadinessSystemAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmergencyShelterReadinessSystemAPI.Dto
{
    public class ShelterWithAreaDto
    {
        public int ShelterId { get; set; }
        public string ShelterName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
    }
}
