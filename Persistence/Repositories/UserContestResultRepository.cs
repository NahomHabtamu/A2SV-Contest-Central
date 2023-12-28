using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UserContestResultRepository : GenericRepository<UserContestResultEntity>, IUserContestResultRepository
{
    private readonly AppDBContext _dbContext;
    
    public UserContestResultRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserContestResultEntity> GetUserContestResultByUserIdAsync(Guid userId)
    {
        return await _dbContext.UserContestResults.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<List<UserContestResultEntity>> GetUserContestResultByGroupIdAsync(Guid groupId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserContestResultEntity>> GetUserContestResultByLocationIdAsync(Guid locationId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserContestResultEntity>> GetUserContestResultByUserIdAndContestIdAsync(Guid userId, Guid contestId)
    {
        return await _dbContext.UserContestResults.Where(x => x.UserId == userId && x.ContestId == contestId)
            .ToListAsync();
    }
}