using Application.Contracts.Persistence;
using Application.DTOs.TeamContestResult;
using AutoMapper;
using MediatR;

namespace Application.Features.TeamContestResult.Queries.GetAllTeamContestResults;

public class GetAllTeamContestResultsHandler : IRequestHandler<GetAllTeamContestResultsQuery, List<TeamContestResultResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTeamContestResultsHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TeamContestResultResponseDto>> Handle(GetAllTeamContestResultsQuery request, CancellationToken cancellationToken)
    {
        var teamContestResults = await _unitOfWork.TeamQuestionResultRepository.GetAllAsync();
        
        return _mapper.Map<List<TeamContestResultResponseDto>>(teamContestResults);
    }
}