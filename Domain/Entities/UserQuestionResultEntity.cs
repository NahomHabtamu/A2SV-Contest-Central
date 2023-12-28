using Domain.Common;

namespace Domain.Entities;

public class UserQuestionResultEntity : BaseDomainEntity
{
    public double Points { get; set; }
    public int RejectedAttemptCount { get; set; }
    public string BestSubmissionTimeSeconds { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    
    public Guid QuestionId { get; set; }
    public QuestionEntity Question { get; set; } = null!;
}