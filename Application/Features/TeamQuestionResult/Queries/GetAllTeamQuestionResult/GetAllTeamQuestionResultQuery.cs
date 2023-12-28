using Application.DTOs.TeamQuestionResult;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetAllTeamQuestionResult;

public class GetAllTeamQuestionResultQuery : IRequest<List<TeamQuestionResultResponseDto>>
{
    
}