using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class TeamContestResultRepository : GenericRepository<TeamContestResultEntity>, ITeamContestResultRepository
{
    private readonly AppDBContext _dbContext;
    
    public TeamContestResultRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TeamContestResultEntity>> GetTeamContestResultByTeamIdAsync(Guid teamId)
    {
        return await _dbContext.TeamContestResults.Where(x => x.TeamId == teamId).ToListAsync();
    }

    public async Task<List<TeamContestResultEntity>> GetTeamContestResultsByGroupIdAsync(Guid groupId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TeamContestResultEntity>> GetTeamContestResultsByLocationIdAsync(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TeamContestResultEntity>> GetTeamContestResultByTeamIdAndContestId(Guid TeamId, Guid ContestId)
    {
        return await _dbContext.TeamContestResults.Where(x => x.TeamId == TeamId && x.ContestId == ContestId)
            .ToListAsync();
    }
}