namespace Application.DTOs.Common;

public class QuestionResultRequestDto
{
    public double Points { get; set; }
    public int RejectedAttemptCount { get; set; }
    public int BestSubmissionTimeSeconds { get; set; }
    public Guid QuestionId { get; set; }
}