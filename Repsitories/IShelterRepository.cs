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
        Task<IEnumerable<FailedInspectionDto>> GetFailedInspection();
        Task<IEnumerable<AreaStatisticsDto>> GetAreaStatistics();
        Task<PagedResultDto<ShelterSortedDto>> GetPagedResult(int page, int pageSize = 10);
    }

}
