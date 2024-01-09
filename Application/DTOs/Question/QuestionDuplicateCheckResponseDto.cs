using Domain.Common;

namespace Application.DTOs.Question;

public class QuestionDuplicateCheckResponseDto
{
    public bool IsDuplicated { get; set; }
    public List<string> Group { get; set; } = new List<string>();
    public int NumberOfTimesUsed { get; set; }
}