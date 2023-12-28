using Application.Contracts.Persistence.Common;
using Application.DTOs.TeamQuestionResult;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ITeamQuestionResultRepository : IGenericRepository<TeamQuestionResultEntity>
{
    Task<List<TeamQuestionResultEntity>> GetTeamQuestionResultsByTeamIdAsync(Guid teamId);
    Task<TeamQuestionResultEntity> GetTeamQuestionResultByQuestionIdTeamId(Guid requestQuestionId, Guid requestUserId);
}