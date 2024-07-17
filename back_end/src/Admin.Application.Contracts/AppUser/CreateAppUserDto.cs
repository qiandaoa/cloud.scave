namespace Admin.Application.Contracts.AppUser;
public class CreateAppUserDto
{
    public string UserName { get; set;} = null!;
    public string Password { get; set;} = null!;
    public string ConfirmPassword { get; set; } = null!;
}