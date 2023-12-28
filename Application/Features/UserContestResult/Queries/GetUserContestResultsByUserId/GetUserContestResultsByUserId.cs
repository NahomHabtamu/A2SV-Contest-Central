using Application.DTOs.UserContestResult;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetUserContestResultsByUserId;

public class GetUserContestResultsByUserId : IRequest<List<UserContestResultResponseDto>>
{
    public Guid UserId { get; set; }
}