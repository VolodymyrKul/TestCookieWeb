using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Models;

namespace TestCookieWeb.Core.Abstractions.IServices
{
    public interface IAuthenticationService
    {
        Task<string> GetAccessTokenAsync(User user);
        Task<string> RefreshUserTokenAsync(int userId, string oldRefreshToken);
    }
}
