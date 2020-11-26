using System;
using System.Collections.Generic;
using System.Text;

namespace TestCookieWeb.Core.DTO
{
    public class UserRequestDTO
    {
        public int Id { get; set; }
        public int? IdApproveUser { get; set; }
        public int? IdRequest { get; set; }
        public int? IdComment { get; set; }
        public string ApproveUserEmail { get; set; }
        public string RequestTitle { get; set; }
        public string CommentTitle { get; set; }
        public string ApproveStatus { get; set; }
    }
}
