using Admin2024.Domain;

namespace Admin2024.Application.Contracts.UserApplication.Dto;
public class UserCreateInfoDto
{
   public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string NickName { get; set; } =null;
    public string Email { get; set; } = null;
    public string Telephone { get; set; } = null;
    public string Remark { get; set; } = null;
}