using Application.DTOs.UserContestResult;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetAllUserContestResultByLocation;

public class GetAllUserContestResultByLocationQuery : IRequest<List<UserContestResultResponseDto>>
{
    public Guid LocationId { get; set; }
}