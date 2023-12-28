using Application.Contracts.Persistence.Common;
using Application.DTOs.Contest;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IContestRepository : IGenericRepository<ContestEntity>
    {
        Task<IReadOnlyList<ContestEntity>> GetContestsOfUser(Guid userId);
        Task<IReadOnlyList<ContestEntity>> GetContestOfTeam(Guid teamId);
        Task<IReadOnlyList<ContestEntity>> GetContestsOfGroup(Guid groupId);
        Task<IReadOnlyList<ContestEntity>> GetContestsOfLocation(Guid locationId);
    }
}