namespace Application.DTOs.UserQuestionResult;

public class UserQuestionsResultRequestDto
{
    public double Points { get; set; }
    public int RejectedAttemptCount { get; set; }
    public int BestSubmissionTimeSeconds { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
}