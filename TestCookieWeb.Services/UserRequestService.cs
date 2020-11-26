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
    public class UserRequestService : BaseService, IUserRequestService
    {
        public UserRequestService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(UserRequestDTO entity)
        {
            var value = new UserRequest();
            _mapper.Map(entity, value);
            await unitOfWork.UserRequestRepo.AddAsync(value);
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.UserRequestRepo.GetByIdAsync(id);
            await unitOfWork.UserRequestRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<UserRequestDTO>> GetAll()
        {
            var userRequests = await unitOfWork.UserRequestRepo.GetAllAsync();
            List<UserRequestDTO> userRequestDTOs = userRequests.Select(userRequest => _mapper.Map(userRequest, new UserRequestDTO())).ToList();
            return userRequestDTOs;
        }

        public virtual async Task<UserRequestDTO> GetIdAsync(int id)
        {
            var userRequest = await unitOfWork.UserRequestRepo.GetByIdAsync(id);
            if (userRequest == null)
                throw new Exception("Such order not found");
            var dto = new UserRequestDTO();
            _mapper.Map(userRequest, dto);
            return dto;
        }

        public virtual async Task<UserRequestDTO> UpdateAsync(UserRequestDTO entity)
        {
            var value = new UserRequest();
            _mapper.Map(entity, value);
            await unitOfWork.UserRequestRepo.UpdateAsync(value);
            return entity;
        }
    }
}
