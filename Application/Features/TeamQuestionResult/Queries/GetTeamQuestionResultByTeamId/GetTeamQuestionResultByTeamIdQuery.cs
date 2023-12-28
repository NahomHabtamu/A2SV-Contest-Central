using Application.DTOs.TeamQuestionResult;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByTeamId;

public class GetTeamQuestionResultByTeamIdQuery : IRequest<List<TeamQuestionResultResponseDto>>
{
    public Guid TeamId { get; set; }
}