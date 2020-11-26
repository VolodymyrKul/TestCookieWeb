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
    public class UserRequestRepo : BaseRepo<UserRequest>, IUserRequestRepo
    {
        private readonly TestCookiesDbContext _context;
        public UserRequestRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<UserRequest>> GetAllAsync()
        {
            return await _context.Set<UserRequest>()
                .Include(userRequest => userRequest.IdApproveUserNavigation)
                .Include(userRequest => userRequest.IdCommentNavigation)
                .Include(userRequest => userRequest.IdRequestNavigation)
                .ToListAsync();
        }
        public override async Task<UserRequest> GetByIdAsync(int id)
        {
            return await _context.Set<UserRequest>()
                .Where(e => e.Id == id)
                .Include(userRequest => userRequest.IdApproveUserNavigation)
                .Include(userRequest => userRequest.IdCommentNavigation)
                .Include(userRequest => userRequest.IdRequestNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
