using Admin2024.Domain;

namespace Admin2024.Application.Contracts.UserApplication.Dto;
public class UserCreateInfoDto:BaseEntity
{
   public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string NickName { get; set; } =null;
    public string Avatar { get; set; } = null;
    public string Salt { get; set; } = null;
    public string Email { get; set; } = null;
    public string Telephone { get; set; } = null;
}