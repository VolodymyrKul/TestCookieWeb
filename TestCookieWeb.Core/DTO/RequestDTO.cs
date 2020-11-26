using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string CreateData { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string PrevStatus { get; set; }
        public int NotApproveUsers { get; set; }
        public int? IdUser { get; set; }
        public string UserEmail { get; set; }
    }
}
