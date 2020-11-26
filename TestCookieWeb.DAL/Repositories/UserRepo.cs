using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IRepositories;
using TestCookieWeb.Core.Models;
using TestCookieWeb.DAL.Repositories.Base;

namespace TestCookieWeb.DAL.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        private readonly TestCookiesDbContext _context;
        public UserRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Set<User>()
                .Include(user => user.IdUserRoleNavigation)
                .ToListAsync();
        }
        public override async Task<User> GetByIdAsync(int id)
        {
            return await _context.Set<User>()
                .Where(e => e.Id == id)
                .Include(user => user.IdUserRoleNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
