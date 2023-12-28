using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class LocationRepository : GenericRepository<LocationEntity>, ILocationRepository
{
    private readonly AppDBContext _dbContext;
    public LocationRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<LocationEntity>> GetByName(string requestLocationName)
    {
        return await _dbContext.Locations.Where(location => location.Location == requestLocationName).ToListAsync();
    }
}