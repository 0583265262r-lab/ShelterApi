using EmergencyShelterReadinessSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace EmergencyShelterReadinessSystemAPI.Dto
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }
        public DateTime InspectionDate { get; set; }
        public int ReadinessScore { get; set; }
        public bool Passed { get; set; }
        public int DefectsCount { set; get; }
        public string Notes { get; set; }
    }
}
