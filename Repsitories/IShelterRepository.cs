using EmergencyShelterReadinessSystemAPI.Dto;

namespace EmergencyShelterReadinessSystemAPI.Repsitories
{
    public interface IShelterRepository
    {
        Task<IEnumerable<ShelterWithAreaDto>> GetAllSheltersWithArea();
        Task<IEnumerable<ShelterByFilterDto>> SearchShelterByFilter(string? city, int? minCapacity, bool? isAccessible, bool? isPublic);
        Task<IEnumerable<ShelterSortedDto>> GetShelterSorted(string sortBy, bool ascending = true);
        Task<IEnumerable<InspectionDetailedDto>> GetInspectionDetaeled();
        Task<IEnumerable<ShelterWithInspectionCountDto>> GetShelterWithInspectionCount();
    }

}
