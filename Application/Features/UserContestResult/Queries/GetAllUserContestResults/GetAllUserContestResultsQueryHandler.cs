using Application.Contracts.Persistence;
using Application.DTOs.UserContestResult;
using AutoMapper;
using MediatR;

namespace Application.Features.UserContestResult.Queries.GetAllUserContestResults;

public class GetAllUserContestResultsQueryHandler : IRequestHandler<GetAllUserContestResultsQuery, List<UserContestResultResponseDto>>
{
    private readonly IUserContestResultRepository _userContestResultRepository;
    private readonly IMapper _mapper;

    public GetAllUserContestResultsQueryHandler(IUserContestResultRepository userContestResultRepository, IMapper mapper)
    {
        _userContestResultRepository = userContestResultRepository;
        _mapper = mapper;
    }

    public async Task<List<UserContestResultResponseDto>> Handle(GetAllUserContestResultsQuery query, CancellationToken cancellationToken)
    {
        var userContestResults = await _userContestResultRepository.GetAllAsync();
        
        return _mapper.Map<List<UserContestResultResponseDto>>(userContestResults);
    }
}