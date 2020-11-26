using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices.Base;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Core.Models;

namespace TestCookieWeb.Core.Abstractions.IServices
{
    public interface IUserService : IBaseService<UserDTO>
    {
        Task<User> GetUserByCredentialsAsync(string email, string password);
    }
}
