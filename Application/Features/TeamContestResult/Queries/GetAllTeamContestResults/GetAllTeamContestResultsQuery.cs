using Application.DTOs.TeamContestResult;
using MediatR;

namespace Application.Features.TeamContestResult.Queries.GetAllTeamContestResults;

public class GetAllTeamContestResultsQuery : IRequest<List<TeamContestResultResponseDto>>
{
    
}