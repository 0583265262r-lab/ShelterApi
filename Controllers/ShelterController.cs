using EmergencyShelterReadinessSystemAPI.Dto;
using EmergencyShelterReadinessSystemAPI.Repsitories;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyShelterReadinessSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShelterController:ControllerBase
    {
        private IShelterRepository _repository;
        public ShelterController (IShelterRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShelterWithAreaDto>>> GetShelterWithArea()
            => Ok(await _repository.GetAllSheltersWithArea());
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ShelterByFilterDto>>> SearchShelterByFilter(string? city, int? minCapacity, bool? isAccessible,
            bool? isPublic)
            => Ok(await _repository.SearchShelterByFilter(city, minCapacity, isAccessible, isPublic));
        [HttpGet("sorted")]
        public async Task<ActionResult<IEnumerable<ShelterSortedDto>>> GetShelterSorted(string sortBy, bool ascending = true)
            => Ok(await _repository.GetShelterSorted(sortBy, ascending));
        [HttpGet("inspections/detailed")]
        public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> GetInspectionDetaeled()
            => Ok(await _repository.GetInspectionDetaeled());
        [HttpGet("with-inspection-count")]
        public async Task<ActionResult<IEnumerable<ShelterWithInspectionCountDto>>> GetShelterWithInspectionCount()
            => Ok(await _repository.GetShelterWithInspectionCount());
        [HttpGet("inspections/failed")]
        public async Task<ActionResult<IEnumerable<FailedInspectionDto>>> GetFailedInspection()
            => Ok(await _repository.GetFailedInspection());
        [HttpGet("areas/statistics")]
        public async Task<ActionResult<IEnumerable<AreaStatisticsDto>>> GetAreaStatistics()
            => Ok(await _repository.GetAreaStatistics());
        [HttpGet("paged")]
        public async Task<ActionResult<PagedResultDto<ShelterSortedDto>>> GetPagedResult(int page, int pageSize = 10)
        {
            if (page < 1)
                return BadRequest();
            if (pageSize > 50 | pageSize < 5)
                return BadRequest();
            return Ok(await _repository.GetPagedResult(page, pageSize));
        }
    }
}
