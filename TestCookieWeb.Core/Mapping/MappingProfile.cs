using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Core.Models;

namespace TestCookieWeb.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserRoleTitle, opts => opts.MapFrom(item => item.IdUserRoleNavigation.Title))
                .ForMember(dest => dest.NotificationPermission, opts => opts.MapFrom(item => BoolToString(item.NotificationPermission)))
                .ForMember(dest => dest.Birthdate, opts => opts.MapFrom(item => item.Birthdate.ToString()))
                .ForMember(dest => dest.RegisterDate, opts => opts.MapFrom(item => item.RegisterDate.ToString()));

            CreateMap<UserRole, UserRoleDTO>()
                .ForMember(dest => dest.ChangeUserRole, opts => opts.MapFrom(item => BoolToString(item.ChangeUserRole)))
                .ForMember(dest => dest.ManageUserList, opts => opts.MapFrom(item => BoolToString(item.ManageUserList)))
                .ForMember(dest => dest.WorkWithHierarchy, opts => opts.MapFrom(item => BoolToString(item.WorkWithHierarchy)));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.NotificationPermission, opts => opts.MapFrom(item => StringToBool(item.NotificationPermission)))
                .ForMember(dest => dest.Birthdate, opts => opts.MapFrom(item => DateTime.Parse(item.Birthdate)))
                .ForMember(dest => dest.RegisterDate, opts => opts.MapFrom(item => DateTime.Parse(item.RegisterDate)));

            CreateMap<UserRoleDTO, UserRole>()
                .ForMember(dest => dest.ChangeUserRole, opts => opts.MapFrom(item => StringToBool(item.ChangeUserRole)))
                .ForMember(dest => dest.ManageUserList, opts => opts.MapFrom(item => StringToBool(item.ManageUserList)))
                .ForMember(dest => dest.WorkWithHierarchy, opts => opts.MapFrom(item => StringToBool(item.WorkWithHierarchy)));

            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.DepHeadEmail, opts => opts.MapFrom(item => item.IdDepHeadNavigation.Email));

            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.CreateDate, opts => opts.MapFrom(item => item.CreateDate.ToString()));

            CreateMap<DepartmentUser, DepUserDTO>()
                .ForMember(dest => dest.DepartmentTitle, opts => opts.MapFrom(item => item.IdDepartmentNavigation.Title))
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email));

            CreateMap<Notification, NotificationDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.Read, opts => opts.MapFrom(item => BoolToString(item.Read)));

            CreateMap<Request, RequestDTO>()
                .ForMember(dest => dest.UserEmail, opts => opts.MapFrom(item => item.IdUserNavigation.Email))
                .ForMember(dest => dest.CreateData, opts => opts.MapFrom(item => item.CreateData.ToString()))
                .ForMember(dest => dest.EndDate, opts => opts.MapFrom(item => item.EndDate.ToString()));

            CreateMap<UserRequest, UserRequestDTO>()
                .ForMember(dest => dest.ApproveUserEmail, opts => opts.MapFrom(item => item.IdApproveUserNavigation.Email))
                .ForMember(dest => dest.RequestTitle, opts => opts.MapFrom(item => item.IdRequestNavigation.Title))
                .ForMember(dest => dest.CommentTitle, opts => opts.MapFrom(item => item.IdCommentNavigation.Title))
                .ForMember(dest => dest.ApproveStatus, opts => opts.MapFrom(item => BoolToString(item.ApproveStatus)));

            CreateMap<DepartmentDTO, Department>();

            CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.CreateDate, opts => opts.MapFrom(item => DateTime.Parse(item.CreateDate)));

            CreateMap<DepUserDTO, DepartmentUser>();

            CreateMap<NotificationDTO, Notification>()
                .ForMember(dest => dest.Read, opts => opts.MapFrom(item => StringToBool(item.Read)));

            CreateMap<RequestDTO, Request>()
                .ForMember(dest => dest.CreateData, opts => opts.MapFrom(item => DateTime.Parse(item.CreateData)))
                .ForMember(dest => dest.EndDate, opts => opts.MapFrom(item => DateTime.Parse(item.EndDate)));

            CreateMap<UserRequestDTO, UserRequest>()
                .ForMember(dest => dest.ApproveStatus, opts => opts.MapFrom(item => StringToBool(item.ApproveStatus)));
        }
        private string BoolToString(bool item)
        {
            if (item)
                return "+";
            else
                return "-";
        }
        private bool StringToBool(string item)
        {
            if (item == "+")
                return true;
            else
                return false;
        }
    }
}
