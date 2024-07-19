namespace Admin2024.Domain.System;

public class User : BaseEntity
{
    public static List<Role> _userRole { get; set; } = new List<Role>();
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? NickName { get; set; }
    public string? Avatar { get; set; }
    public string? Salt { get; set; }
    public string? Email { get; set; }
    public string? Telephone { get; set; }
    
    public static void AllocateRole(Role role)
    {
        _userRole.Add(role);
    }
    public static void RemoveRole(string roleName)
    {
        var role = _userRole.FirstOrDefault(e => e.RoleName == roleName);
        if(role != null)
        {
            _userRole.Remove(role);
        }
    }
    public static bool ValidatePwd(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= 8;
    }
}