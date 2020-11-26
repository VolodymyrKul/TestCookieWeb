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
    public class DepartmentRepo : BaseRepo<Department>, IDepartmentRepo
    {
        private readonly TestCookiesDbContext _context;
        public DepartmentRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Set<Department>()
                .Include(department => department.IdDepHeadNavigation)
                .ToListAsync();
        }
        public override async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Set<Department>()
                .Where(e => e.Id == id)
                .Include(department => department.IdDepHeadNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
