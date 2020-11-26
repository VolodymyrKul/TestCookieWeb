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
    public class UserRoleService : BaseService, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(UserRoleDTO entity)
        {
            var value = new UserRole();
            _mapper.Map(entity, value);
            await unitOfWork.UserRoleRepo.AddAsync(value);
            await unitOfWork.SaveChangesAsync();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.UserRoleRepo.GetByIdAsync(id);
            await unitOfWork.UserRoleRepo.DeleteAsync(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UserRoleDTO>> GetAll()
        {
            var userRoles = await unitOfWork.UserRoleRepo.GetAllAsync();
            List<UserRoleDTO> userRoleDTOs = userRoles.Select(userRole => _mapper.Map(userRole, new UserRoleDTO())).ToList();
            return userRoleDTOs;
        }

        public virtual async Task<UserRoleDTO> GetIdAsync(int id)
        {
            var userRole = await unitOfWork.UserRoleRepo.GetByIdAsync(id);
            if (userRole == null)
                throw new Exception("Such order not found");
            var dto = new UserRoleDTO();
            _mapper.Map(userRole, dto);
            return dto;
        }

        public virtual async Task<UserRoleDTO> UpdateAsync(UserRoleDTO entity)
        {
            var value = new UserRole();
            _mapper.Map(entity, value);
            await unitOfWork.UserRoleRepo.UpdateAsync(value);
            await unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
