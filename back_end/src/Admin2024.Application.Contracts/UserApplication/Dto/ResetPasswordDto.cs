namespace Admin2024.Application.Contracts.UserApplication.Dto;

public class ResetPasswordDto
{
    public string NewPassword { get; set; } = null!;
    public string ConfirmNewPassword { get; set; } = null!;
    
}