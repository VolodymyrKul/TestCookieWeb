﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Core.Models;
using TestCookieWeb.Services.Base;

namespace TestCookieWeb.Services
{
    public class RequestService : BaseService, IRequestService
    {
        public RequestService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(RequestDTO entity)
        {
            var value = new Request();
            _mapper.Map(entity, value);
            await unitOfWork.RequestRepo.AddAsync(value);
            await AddUserReq();
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.RequestRepo.GetByIdAsync(id);
            await DelUserReq(entity);
            await unitOfWork.RequestRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<RequestDTO>> GetAll()
        {
            var requests = await unitOfWork.RequestRepo.GetAllAsync();
            List<RequestDTO> requestDTOs = requests.Select(request => _mapper.Map(request, new RequestDTO())).ToList();
            return requestDTOs;
        }

        public virtual async Task<RequestDTO> GetIdAsync(int id)
        {
            var request = await unitOfWork.RequestRepo.GetByIdAsync(id);
            if (request == null)
                throw new Exception("Such order not found");
            var dto = new RequestDTO();
            _mapper.Map(request, dto);
            return dto;
        }

        public virtual async Task<RequestDTO> UpdateAsync(RequestDTO entity)
        {
            var value = new Request();
            _mapper.Map(entity, value);
            await unitOfWork.RequestRepo.UpdateAsync(value);
            return entity;
        }

        private async Task AddUserReq()
        {
            List<Request> requests = (await unitOfWork.RequestRepo.GetAllAsync()).ToList();
            Request CreatedRequest = requests[requests.Count - 1];
            List<DepartmentUser> depUsers = (await unitOfWork.DepUserRepo.GetAllAsync()).ToList();
            var depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == CreatedRequest.IdUser);
            while (depHeadUser != null)
            {
                UserRequest userRequest = new UserRequest() 
                { 
                    IdApproveUser = depHeadUser.Id, 
                    IdRequest = CreatedRequest.Id, 
                    IdComment = 1, 
                    ApproveStatus = false 
                };
                await unitOfWork.UserRequestRepo.AddAsync(userRequest);

                Notification notification = new Notification()
                {
                    IdUser = depHeadUser.Id,
                    Title = "New request for approving",
                    Description = "User " + CreatedRequest.IdUserNavigation.Email + " create new request",
                    Read = false
                };
                await unitOfWork.NotificationRepo.AddAsync(notification);

                depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == depHeadUser.IdUser);
            }
        }

        private async Task DelUserReq(Request entity)
        {
            List<DepartmentUser> depUsers = (await unitOfWork.DepUserRepo.GetAllAsync()).ToList();
            var depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == entity.IdUser);
            while (depHeadUser != null)
            {
                string desc = "User " + entity.IdUserNavigation.Email + " create new request";
                List<Notification> notifications = (await unitOfWork.NotificationRepo.GetAllAsync()).ToList();
                var notification = notifications.FirstOrDefault(n => n.IdUser == depHeadUser.Id && n.Description == desc);
                await unitOfWork.NotificationRepo.DeleteAsync(notification);

                List<UserRequest> userRequests = (await unitOfWork.UserRequestRepo.GetAllAsync()).ToList();
                var userRequest = userRequests.FirstOrDefault(ur => ur.IdApproveUser == depHeadUser.Id && ur.IdRequest == entity.Id);
                await unitOfWork.UserRequestRepo.DeleteAsync(userRequest);

                depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == depHeadUser.IdUser);
            }
        }
    }
}
