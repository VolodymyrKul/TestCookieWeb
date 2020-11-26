using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class UserRole : IBaseEntity
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ChangeUserRole { get; set; }
        public bool ManageUserList { get; set; }
        public bool WorkWithHierarchy { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
