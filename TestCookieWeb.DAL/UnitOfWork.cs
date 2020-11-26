using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions;
using TestCookieWeb.Core.Abstractions.IRepositories;
using TestCookieWeb.DAL.Repositories;

namespace TestCookieWeb.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepo _userRepo;
        private IUserRoleRepo _userRoleRepo;
        private ICommentRepo _commentRepo;
        private IDepartmentRepo _departmentRepo;
        private IDepUserRepo _depUserRepo;
        private INotificationRepo _notificationRepo;
        private IRequestRepo _requestRepo;
        private IUserRequestRepo _userRequestRepo;
        private TestCookiesDbContext _context;
        public UnitOfWork(TestCookiesDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
        public IUserRepo UserRepo
        {
            get { return _userRepo ??= new UserRepo(_context); }
        }
        public IUserRoleRepo UserRoleRepo
        {
            get { return _userRoleRepo ??= new UserRoleRepo(_context); }
        }
        public ICommentRepo CommentRepo
        {
            get { return _commentRepo ??= new CommentRepo(_context); }
        }

        public IDepartmentRepo DepartmentRepo
        {
            get { return _departmentRepo ??= new DepartmentRepo(_context); }
        }

        public IDepUserRepo DepUserRepo
        {
            get { return _depUserRepo ??= new DepUserRepo(_context); }
        }

        public INotificationRepo NotificationRepo
        {
            get { return _notificationRepo ??= new NotificationRepo(_context); }
        }

        public IRequestRepo RequestRepo
        {
            get { return _requestRepo ??= new RequestRepo(_context); }
        }
        public IUserRequestRepo UserRequestRepo
        {
            get { return _userRequestRepo ??= new UserRequestRepo(_context); }
        }
    }
}
