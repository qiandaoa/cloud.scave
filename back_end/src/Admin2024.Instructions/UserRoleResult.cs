using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin2024.Instructions
{
    public  class UserRoleResult
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? NickName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsActived { get; set; }

    }
}
