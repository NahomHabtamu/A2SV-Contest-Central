using Application.Contracts.Persistence;
using Application.DTOs.TeamQuestionResult;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByTeamId;

public class GetTeamQuestionResultByTeamIdQueryHandler : IRequestHandler<GetTeamQuestionResultByTeamIdQuery, List<TeamQuestionResultResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamQuestionResultByTeamIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TeamQuestionResultResponseDto>> Handle(GetTeamQuestionResultByTeamIdQuery request, CancellationToken cancellationToken)
    {
        var questionResult =
            await _unitOfWork.TeamQuestionResultRepository.GetTeamQuestionResultsByTeamIdAsync(request.TeamId);
        
        return _mapper.Map<List<TeamQuestionResultResponseDto>>(questionResult);
    }
}