using Application.DTOs.Question;
using MediatR;

namespace Application.Features.Question.Queries.GetQuestionsFromContest;

public class GetQuestionsFromContestRequest : IRequest<IReadOnlyList<QuestionResponseDto>>
{
    public Guid ContestId { get; set; }
}