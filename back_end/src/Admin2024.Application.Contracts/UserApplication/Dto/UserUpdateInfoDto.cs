using Admin2024.Domain;
using Admin2024.Domain.System;

namespace Admin2024.Application.Contracts.UserApplication.Dto;

public class UserUpdateInfoDto
{
    // public string Username { get; set; } = null!;
    public string? NickName { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public string? Telephone { get; set; }
}