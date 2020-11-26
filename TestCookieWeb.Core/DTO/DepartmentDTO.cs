using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? IdDepHead { get; set; }
        public string DepHeadEmail { get; set; }
    }
}
