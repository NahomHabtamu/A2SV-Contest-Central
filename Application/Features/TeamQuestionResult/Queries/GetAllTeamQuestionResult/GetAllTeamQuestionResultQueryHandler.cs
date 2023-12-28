using Application.Contracts.Persistence;
using Application.DTOs.TeamQuestionResult;
using Application.DTOs.UserQuestionResult;
using Application.Features.UserQuestionResult.Queries.GetAllUserQuestionResult;
using AutoMapper;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetAllTeamQuestionResult;

public class GetAllTeamQuestionResultQueryHandler : IRequestHandler<GetAllTeamQuestionResultQuery, List<TeamQuestionResultResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTeamQuestionResultQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<TeamQuestionResultResponseDto>> Handle(GetAllTeamQuestionResultQuery request, CancellationToken cancellationToken)
    {
        var questionResults = await _unitOfWork.TeamQuestionResultRepository.GetAllAsync();
        return _mapper.Map<List<TeamQuestionResultResponseDto>>(questionResults);
    }
}