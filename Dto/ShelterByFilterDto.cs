namespace EmergencyShelterReadinessSystemAPI.Dto
{
    public class ShelterByFilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int capacity { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsPublic { get; set; }
        public string City { get; set; }
    }
}
