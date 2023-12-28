using Application.DTOs.UserContestResult;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetUserContestResultByGroup;

public class GetUserContestResultByGroupQuery : IRequest<List<UserContestResultResponseDto>>
{
    public Guid GroupId { get; set; }
}