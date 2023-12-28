using Application.DTOs.UserQuestionResult;
using MediatR;

namespace Application.Features.UserQuestionResult.Queries.GetAllUserQuestionResult;

public class GetAllUserQuestionResultQuery : IRequest<List<UserQuestionsResultResponseDto>>
{
    
}