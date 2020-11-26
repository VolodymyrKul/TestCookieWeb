using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Read { get; set; }
        public int? IdUser { get; set; }
        public string UserEmail { get; set; }
    }
}
