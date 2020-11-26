using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Abstractions.IRepositories;
using TestCookieWeb.Core.Models;
using TestCookieWeb.DAL.Repositories.Base;

namespace TestCookieWeb.DAL.Repositories
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo
    {
        private readonly TestCookiesDbContext _context;
        public UserRoleRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
