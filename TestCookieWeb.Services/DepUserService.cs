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
    public class DepUserService : BaseService, IDepUserService
    {
        public DepUserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(DepUserDTO entity)
        {
            var value = new DepartmentUser();
            _mapper.Map(entity, value);
            await unitOfWork.DepUserRepo.AddAsync(value);
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.DepUserRepo.GetByIdAsync(id);
            await unitOfWork.DepUserRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<DepUserDTO>> GetAll()
        {
            var depUsers = await unitOfWork.DepUserRepo.GetAllAsync();
            List<DepUserDTO> depUserDTOs = depUsers.Select(depUser => _mapper.Map(depUser, new DepUserDTO())).ToList();
            return depUserDTOs;
        }

        public virtual async Task<DepUserDTO> GetIdAsync(int id)
        {
            var depUser = await unitOfWork.DepUserRepo.GetByIdAsync(id);
            if (depUser == null)
                throw new Exception("Such order not found");
            var dto = new DepUserDTO();
            _mapper.Map(depUser, dto);
            return dto;
        }

        public virtual async Task<DepUserDTO> UpdateAsync(DepUserDTO entity)
        {
            var value = new DepartmentUser();
            _mapper.Map(entity, value);
            await unitOfWork.DepUserRepo.UpdateAsync(value);
            return entity;
        }
    }
}
