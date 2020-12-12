using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices.Base;
using TestCookieWeb.Core.DTO;

namespace TestCookieWeb.Core.Abstractions.IServices
{
    public interface IRequestService : IBaseService<RequestDTO>
    {
        Task<List<RequestDTO>> GetAllApprove(int UserId);
    }
}
