using EmergencyShelterReadinessSystemAPI.Dto;

namespace EmergencyShelterReadinessSystemAPI.Repsitories
{
    public interface IShelterRepository
    {
        Task<IEnumerable<ShelterWithAreaDto>> GetAllSheltersWithArea();
    }
}
