using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class User : IBaseEntity
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool NotificationPermission { get; set; }
        public int? IdUserRole { get; set; }

        public virtual UserRole IdUserRoleNavigation { get; set; }
    }
}
