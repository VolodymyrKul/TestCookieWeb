using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ChangeUserRole { get; set; }
        public string ManageUserList { get; set; }
        public string WorkWithHierarchy { get; set; }
    }
}
