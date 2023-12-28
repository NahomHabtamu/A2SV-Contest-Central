using Application.DTOs.Common;
using Application.DTOs.TeamQuestionResult;
using Application.DTOs.UserQuestionResult;

namespace Application.DTOs.Question;

public class QuestionResponseDto : BaseDto
{
    public Guid ContestId { get; set; }
    
    public string GlobalQuestionUrl { get; set; } = null!;
    
    public string Name { get; set; } = string.Empty;
    
    public string Index { get; set; } = string.Empty;
    
    public List<UserQuestionsResultResponseDto> UserQuestionResults { get; set; } = new List<UserQuestionsResultResponseDto>();
    
    public List<TeamQuestionResultResponseDto> TeamQuestionResults { get; set; } = new List<TeamQuestionResultResponseDto>();
}