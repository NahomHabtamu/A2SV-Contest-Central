using Application.DTOs.TeamQuestionResult;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByQuestionIdTeamId;

public class GetTeamQuestionResultByQuestionIdTeamIdQuery : IRequest<TeamQuestionResultResponseDto>
{
    public Guid TeamId { get; set; }
    public Guid QuestionId { get; set; }
}