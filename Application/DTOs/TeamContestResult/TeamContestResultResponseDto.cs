using Application.DTOs.Common;
using Application.DTOs.Team;

namespace Application.DTOs.TeamContestResult;

public class TeamContestResultResponseDto : ContestResultDto
{
    public Guid TeamId { get; set; }
    public TeamResponseDto Team { get; set; } = null!;
}