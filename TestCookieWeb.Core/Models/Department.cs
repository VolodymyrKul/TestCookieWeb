using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class Department : IBaseEntity
    {
        public Department()
        {
            DepartmentUser = new HashSet<DepartmentUser>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? IdDepHead { get; set; }

        public virtual User IdDepHeadNavigation { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUser { get; set; }
    }
}
