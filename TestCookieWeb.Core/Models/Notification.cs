using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class Notification : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Read { get; set; }
        public int? IdUser { get; set; }

        public User IdUserNavigation { get; set; }
    }
}
