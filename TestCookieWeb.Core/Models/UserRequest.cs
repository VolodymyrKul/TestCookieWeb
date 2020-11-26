using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Models.Base;

namespace TestCookieWeb.Core.Models
{
    public class UserRequest : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdApproveUser { get; set; }
        public int? IdRequest { get; set; }
        public int? IdComment { get; set; }
        public bool ApproveStatus { get; set; }

        public virtual User IdApproveUserNavigation { get; set; }
        public virtual Request IdRequestNavigation { get; set; }
        public virtual Comment IdCommentNavigation { get; set; }
    }
}
