namespace Admin2024.Application.Contracts.UserApplication.Dto;

public class RegisterDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPwd { get; set; } = null!;
}