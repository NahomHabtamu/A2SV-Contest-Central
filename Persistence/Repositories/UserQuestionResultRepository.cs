using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UserQuestionResultRepository : GenericRepository<UserQuestionResultEntity>, IUserQuestionResultRepository
{
    private readonly AppDBContext _dbContext;
    public UserQuestionResultRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserQuestionResultEntity>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.UserQuestionResults.Where(x => x.UserId == userId).ToListAsync();
    }

    public Task<UserQuestionResultEntity> GetUserQuestionResultByQuestionIdUserId(Guid questionId, Guid userId)
    {
        return _dbContext.UserQuestionResults.FirstOrDefaultAsync(x => x.QuestionId == questionId && x.UserId == userId)!;
    }
}