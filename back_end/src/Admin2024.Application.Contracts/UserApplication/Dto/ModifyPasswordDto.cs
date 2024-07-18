namespace Admin2024.Application.Contracts.UserApplication.Dto;

public class ModifyPasswordDto
{
    public string NewPassword { get; set; } = null!;
    public string ConfirmNewPassword { get; set; } = null!;
    
}