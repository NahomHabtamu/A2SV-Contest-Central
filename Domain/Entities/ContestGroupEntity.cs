using Domain.Common;

namespace Domain.Entities;

public class ContestGroupEntity : BaseDomainEntity
{
    public Guid ContestId { get; set; }
    public ContestEntity Contest { get; set; } = null!;
    
    public int GroupId { get; set; }
    public GroupEntity Group { get; set; } = null!;
}