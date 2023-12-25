﻿using Application.DTOs.Common;
using Application.DTOs.Team;

namespace Application.DTOs.TeamContestResult;

public class GetContestResultByTeamResponseDto : ContestResultDto
{
    public Guid TeamId { get; set; }
    public TeamReponseDto Team { get; set; } = null!;
}