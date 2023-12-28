using Application.DTOs.UserContestResult;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetAllUserContestResults;

public class GetAllUserContestResultsQuery : IRequest<List<UserContestResultResponseDto>>
{
    
}