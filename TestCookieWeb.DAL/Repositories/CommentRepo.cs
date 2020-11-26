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
    public class CommentRepo : BaseRepo<Comment>, ICommentRepo
    {
        private readonly TestCookiesDbContext _context;

        public CommentRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Set<Comment>()
                .Include(comment => comment.IdUserNavigation)
                .ToListAsync();
        }
        public override async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Set<Comment>()
                .Where(e => e.Id == id)
                .Include(comment => comment.IdUserNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
