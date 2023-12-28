using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class TeamRepository : GenericRepository<TeamEntity>, ITeamRepository
{
    private readonly AppDBContext _dbContext;
    public TeamRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}