using Application.Contracts.Persistence;
using Application.DTOs.Common;
using Application.DTOs.TeamQuestionResult;
using Application.Exceptions;
using Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByQuestionIdUserId;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TeamQuestionResult.Queries.GetTeamQuestionResultByQuestionIdTeamId;

public class GetUserQuestionResultByQuestionIdUserIdQueryHandler : IRequestHandler<GetTeamQuestionResultByQuestionIdTeamIdQuery, TeamQuestionResultResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserQuestionResultByQuestionIdUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TeamQuestionResultResponseDto> Handle(GetTeamQuestionResultByQuestionIdTeamIdQuery request, CancellationToken cancellationToken)
    {
        var userQuestionResult = await _unitOfWork.TeamQuestionResultRepository.GetTeamQuestionResultByQuestionIdTeamId(request.QuestionId, request.TeamId);
        
        if (userQuestionResult == null)
        {
            throw new Exception("No question result found for this question and user");
        }
        return _mapper.Map<TeamQuestionResultResponseDto>(userQuestionResult);
    }
}