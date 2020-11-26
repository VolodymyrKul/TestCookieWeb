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
    public class NotificationRepo : BaseRepo<Notification>, INotificationRepo
    {
        private readonly TestCookiesDbContext _context;
        public NotificationRepo(TestCookiesDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _context.Set<Notification>()
                .Include(notification => notification.IdUserNavigation)
                .ToListAsync();
        }
        public override async Task<Notification> GetByIdAsync(int id)
        {
            return await _context.Set<Notification>()
                .Where(e => e.Id == id)
                .Include(notification => notification.IdUserNavigation)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
