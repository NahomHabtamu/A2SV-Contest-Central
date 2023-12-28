using Application.DTOs.UserQuestionResult;
using MediatR;

namespace Application.Features.UserQuestionResult.Queries.GetUserQuestionResultByQuestionIdUserId;

public class GetUserQuestionResultByQuestionIdUserIdQuery : IRequest<UserQuestionsResultResponseDto>
{
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
}