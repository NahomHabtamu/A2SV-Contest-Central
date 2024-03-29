﻿using Application.DTOs.Common;

namespace Application.DTOs.User;

public class UserRequestDto : UserUpdateRequestDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ProfilePicture { get; set; }
    public string CoverPicture { get; set; }
    public required string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; } = null!;
    public Guid GroupId { get; set; }
    public Guid UserTypeId { get; set; }
}