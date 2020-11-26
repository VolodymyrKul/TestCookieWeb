using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class DepartmentUser : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdUser { get; set; }

        public virtual Department IdDepartmentNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
