using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories.Common;


namespace Persistence.Repositories
{
    public class ContestRepository : GenericRepository<ContestEntity>, IContestRepository
    {
        public ContestRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

        public Task<IReadOnlyList<ContestEntity>> GetContestOfTeam(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ContestEntity>> GetContestsOfGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ContestEntity>> GetContestsOfLocation(Guid locationId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ContestEntity>> GetContestsOfUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}