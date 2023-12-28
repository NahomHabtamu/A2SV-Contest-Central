using Application.DTOs.Common;
using Application.DTOs.Question;
using Application.DTOs.Team;

namespace Application.DTOs.TeamQuestionResult;

public class TeamQuestionResultResponseDto : QuestionResultResponseDto
{
    public Guid TeamId { get; set; }
    public TeamResponseDto Team { get; set; } = null!;
}