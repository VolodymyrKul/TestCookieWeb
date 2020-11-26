using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IRepositories;

namespace TestCookieWeb.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo UserRepo { get; }
        IUserRoleRepo UserRoleRepo { get; }
        ICommentRepo CommentRepo { get; }
        IDepartmentRepo DepartmentRepo { get; }
        IDepUserRepo DepUserRepo { get; }
        INotificationRepo NotificationRepo { get; }
        IRequestRepo RequestRepo { get; }
        IUserRequestRepo UserRequestRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
