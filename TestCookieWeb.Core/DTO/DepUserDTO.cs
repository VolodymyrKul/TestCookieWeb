using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class DepUserDTO
    {
        public int Id { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdUser { get; set; }
        public string DepartmentTitle { get; set; }
        public string UserEmail { get; set; }
    }
}
