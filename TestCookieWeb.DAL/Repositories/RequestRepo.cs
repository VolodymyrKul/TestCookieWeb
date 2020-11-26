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
    public class RequestRepo : BaseRepo<Request>, IRequestRepo
    {
        private readonly TestCookiesDbContext _context;
        public RequestRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Set<Request>()
                .Include(request => request.IdUserNavigation)
                .ToListAsync();
        }
        public override async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Set<Request>()
                .Where(e => e.Id == id)
                .Include(request => request.IdUserNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
