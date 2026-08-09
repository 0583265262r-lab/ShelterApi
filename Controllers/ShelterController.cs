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
        

    }
}
