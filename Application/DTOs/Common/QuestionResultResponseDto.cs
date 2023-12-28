using Application.DTOs.Question;

namespace Application.DTOs.Common;

public class QuestionResultResponseDto : BaseDto
{
    public double Points { get; set; }
    public int RejectedAttemptCount { get; set; }
    public string BestSubmissionTimeSeconds { get; set; } = null!;
    public Guid QuestionId { get; set; }
    public QuestionResponseDto Question { get; set; } = null!;
}