﻿using Domain.Common;

namespace Domain.Entities;

public class TeamContestResultEntity : BaseDomainEntity
{
    public float Points { get; set; }
    public int Rank { get; set; }
    public int Penalty { get; set; }
    public int SuccessfulHackCount { get; set; }
    public int UnsuccessfulHackCount { get; set; }
    public bool IsVirtual { get; set; }
    
    public Guid TeamId { get; set; }
    public TeamEntity Team { get; set; } = null!;
    
    public Guid ContestId { get; set; }
    public ContestEntity Contest { get; set; } = null!;
}