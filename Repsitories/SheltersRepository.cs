using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.Models;
using EmergencyShelterReadinessSystemAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmergencyShelterReadinessSystemAPI.Repsitories
{
    public class SheltersRepository: IShelterRepository
    {
        private readonly ShelterDBContext _context;
        public SheltersRepository(ShelterDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShelterWithAreaDto>>GetAllSheltersWithArea()
        {
            return await _context.Shelters
                .Include(s => s.Area)
                .Select(s => new ShelterWithAreaDto
                {
                    ShelterId = s.Id,
                    ShelterName = s.Name,
                    Capacity = s.Capacity,
                    City = s.Area.City,
                    Neighborhood = s.Area.Neighborhood
                }).ToListAsync();
        }
    }
}
