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
    public class DepUserRepo : BaseRepo<DepartmentUser>, IDepUserRepo
    {
        private readonly TestCookiesDbContext _context;
        public DepUserRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<DepartmentUser>> GetAllAsync()
        {
            return await _context.Set<DepartmentUser>()
                .Include(depUser => depUser.IdDepartmentNavigation)
                .Include(depUser => depUser.IdUserNavigation)
                .ToListAsync();
        }
        public override async Task<DepartmentUser> GetByIdAsync(int id)
        {
            return await _context.Set<DepartmentUser>()
                .Where(e => e.Id == id)
                .Include(depUser => depUser.IdDepartmentNavigation)
                .Include(depUser => depUser.IdUserNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
