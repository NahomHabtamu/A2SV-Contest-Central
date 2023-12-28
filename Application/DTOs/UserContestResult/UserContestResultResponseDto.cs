using Application.DTOs.Common;
using Application.DTOs.User;

namespace Application.DTOs.UserContestResult;

public class UserContestResultResponseDto : ContestResultDto
{
    public Guid UserId { get; set; }
    public UserResponseDto User { get; set; } = null!;
}