using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string Birthdate { get; set; }
        public string RegisterDate { get; set; }
        public string NotificationPermission { get; set; }
        public int? IdUserRole { get; set; }
        public string UserRoleTitle { get; set; }
    }
}
