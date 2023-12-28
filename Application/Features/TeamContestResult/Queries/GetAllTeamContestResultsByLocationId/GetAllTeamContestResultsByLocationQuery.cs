using Application.DTOs.TeamContestResult;
using MediatR;

namespace Application.Features.TeamContestResult.Queries.GetAllTeamContestResultsByLocationId;

public class GetAllTeamContestResultsByLocationQuery : IRequest<List<TeamContestResultResponseDto>>
{
    public Guid LocationId { get; set; }
}