using Application.Contracts.Persistence;
using Application.DTOs.Common;
using Application.DTOs.UserQuestionResult;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByQuestionIdUserId;

public class GetUserQuestionResultByQuestionIdUserIdQueryHandler : IRequestHandler<GetUserQuestionResultByQuestionIdUserIdQuery, UserQuestionsResultResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserQuestionResultByQuestionIdUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserQuestionsResultResponseDto> Handle(GetUserQuestionResultByQuestionIdUserIdQuery request, CancellationToken cancellationToken)
    {
        var userQuestionResult = await _unitOfWork.UserQuestionResultRepository.GetUserQuestionResultByQuestionIdUserId(request.QuestionId, request.UserId);
        
        if (userQuestionResult == null)
        {
            throw new Exception("No question result found for this question and user");
        }
        return _mapper.Map<UserQuestionsResultResponseDto>(userQuestionResult);
    }
}