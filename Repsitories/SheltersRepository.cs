using EmergencyShelterReadinessSystemAPI.Data;
using EmergencyShelterReadinessSystemAPI.Dto;
using EmergencyShelterReadinessSystemAPI.Enums;
using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
        public async Task<IEnumerable<ShelterByFilterDto>>SearchShelterByFilter(string? city,int? minCapacity,bool? isAccessible,
            bool? isPublic)
        {
            var query = _context.Shelters
                .Include(s => s.Area)
                .AsQueryable();
                
            if(!string.IsNullOrEmpty(city))
                query = query.Where(s => s.Area.City == city);
            if (minCapacity.HasValue)
                query = query.Where(s => s.Capacity >= minCapacity.Value);
            if (isAccessible.HasValue)
                query = query.Where(s => s.IsAccessible == isAccessible.Value);
            if (isPublic.HasValue)
                query = query.Where(s => s.IsPublic == isPublic.Value);
            return await query
                .Select(s => new ShelterByFilterDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    City = s.Area.City,
                    Street = s.Street,
                    capacity = s.Capacity,
                    IsAccessible = s.IsAccessible,
                    IsPublic = s.IsPublic
                }).ToListAsync();
        }
        public async Task<IEnumerable<ShelterSortedDto>>GetShelterSorted(string? sortBy,bool ascending = true)
        {
            var query = _context.Shelters
                .Include(s => s.Area)
                .AsQueryable();
            query = sortBy.ToLower() switch
            {
                "capacity" => ascending == true ? query.OrderBy(s => s.Capacity) : query.OrderByDescending(s => s.Capacity),
                "city" => ascending == true ? query.OrderBy(s => s.Area.City) : query.OrderByDescending(s => s.Area.City),
                _ => ascending == true ? query.OrderBy(s => s.Name) : query.OrderByDescending(s => s.Name)
            };
            return await query
                .Select(s => new ShelterSortedDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    City = s.Area.City,
                    Neighborhood = s.Area.Neighborhood,
                    Street = s.Street,
                    BuildingNumber = s.BuildingNumber,
                    Capacity = s.Capacity,
                    IsAccessible = s.IsAccessible,
                    IsPublic = s.IsPublic,
                    ShelterType = s.ShelterType
                }).ToListAsync();
        }
        public async Task<IEnumerable<InspectionDetailedDto>>GetInspectionDetaeled()
        {
            return await _context.Inspections
                .Include(i => i.Shelter)
                .ThenInclude(s => s.Area)
                .Select(i => new InspectionDetailedDto
                {
                    inspectionId = i.Id,
                    InspectionDate = i.InspectionDate,
                    ReadinessScore = i.ReadinessScore,
                    Passed = i.Passed,
                    ShelterName = i.Shelter.Name,
                    City = i.Shelter.Area.City,
                    Neighborhood = i.Shelter.Area.Neighborhood
                }).ToListAsync();       
        }
        public async Task<IEnumerable<ShelterWithInspectionCountDto>> GetShelterWithInspectionCount()
        {
            return await _context.Shelters
                .Select(s => new ShelterWithInspectionCountDto
                {
                    ShelterId = s.Id,
                    ShelterName = s.Name,
                    InspectionCount = s.Inspections.Count()
                }).ToListAsync();
        }
    }
}
