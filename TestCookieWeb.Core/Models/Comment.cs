using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class Comment : IBaseEntity
    {
        public Comment()
        {
            UserRequest = new HashSet<UserRequest>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<UserRequest> UserRequest { get; set; }
    }
}
