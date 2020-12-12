using AutoMapper;
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
            List<Department> departs = (await unitOfWork.DepartmentRepo.GetAllAsync()).ToList();
            var depUser = depUsers.FirstOrDefault(u => u.IdUser == CreatedRequest.IdUser);
            while (depUser != null)
            {
                var userDepart = departs.FirstOrDefault(d => d.Id == depUser.IdDepartment);
                UserRequest userRequest = new UserRequest() 
                { 
                    IdApproveUser = userDepart.IdDepHead, 
                    IdRequest = CreatedRequest.Id, 
                    IdComment = 1, 
                    ApproveStatus = false 
                };
                await unitOfWork.UserRequestRepo.AddAsync(userRequest);

                Notification notification = new Notification()
                {
                    IdUser = userDepart.Id,
                    Title = "New request for approving",
                    Description = "User " + CreatedRequest.IdUserNavigation.Email + " create new request",
                    Read = false
                };
                await unitOfWork.NotificationRepo.AddAsync(notification);

                depUser = depUsers.FirstOrDefault(u => u.IdUser == userDepart.IdDepHead);
            }
        }

        private async Task DelUserReq(Request entity)
        {
            List<DepartmentUser> depUsers = (await unitOfWork.DepUserRepo.GetAllAsync()).ToList();
            List<Department> departs = (await unitOfWork.DepartmentRepo.GetAllAsync()).ToList();
            var depUser = depUsers.FirstOrDefault(u => u.IdUser == entity.IdUser);
            //var depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == entity.IdUser);
            while (depUser != null)
            {
                var userDepart = departs.FirstOrDefault(d => d.Id == depUser.IdDepartment);
                string desc = "User " + entity.IdUserNavigation.Email + " create new request";
                List<Notification> notifications = (await unitOfWork.NotificationRepo.GetAllAsync()).ToList();
                var notification = notifications.FirstOrDefault(n => n.IdUser == userDepart.IdDepHead && n.Description == desc);
                await unitOfWork.NotificationRepo.DeleteAsync(notification);

                List<UserRequest> userRequests = (await unitOfWork.UserRequestRepo.GetAllAsync()).ToList();
                var userRequest = userRequests.FirstOrDefault(ur => ur.IdApproveUser == userDepart.IdDepHead && ur.IdRequest == entity.Id);
                await unitOfWork.UserRequestRepo.DeleteAsync(userRequest);

                depUser = depUsers.FirstOrDefault(u => u.IdUser == userDepart.IdDepHead);
                //depHeadUser = depUsers.FirstOrDefault(u => u.IdUser == depHeadUser.IdUser);
            }
        }

        public virtual async Task<List<RequestDTO>> GetAllApprove(int UserId) {
            var userreqs = (await unitOfWork.UserRequestRepo.GetAllAsync()).ToList();
            var approveIds = userreqs.Where(u => u.IdApproveUser == UserId).Select(u=>u.IdRequest);
            var distinctIds = approveIds.Distinct();
            List<RequestDTO> requestDTOs = new List<RequestDTO>();
            foreach (int ItemId in distinctIds)
            {
                var requests = await unitOfWork.RequestRepo.GetAllAsync();
                requestDTOs.Add(_mapper.Map(requests.FirstOrDefault(r => r.Id == ItemId), new RequestDTO()));
            }
            return requestDTOs;
        }
    }
}
