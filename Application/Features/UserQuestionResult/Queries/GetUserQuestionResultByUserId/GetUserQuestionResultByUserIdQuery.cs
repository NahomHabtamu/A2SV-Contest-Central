using Application.DTOs.UserQuestionResult;
using MediatR;

namespace Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByUserId;

public class GetUserQuestionResultByUserIdQuery : IRequest<List<UserQuestionsResultResponseDto>>
{
    public Guid UserId { get; set; }
}