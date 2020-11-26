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
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(DepartmentDTO entity)
        {
            var value = new Department();
            _mapper.Map(entity, value);
            await unitOfWork.DepartmentRepo.AddAsync(value);
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.DepartmentRepo.GetByIdAsync(id);
            await unitOfWork.DepartmentRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<DepartmentDTO>> GetAll()
        {
            var departments = await unitOfWork.DepartmentRepo.GetAllAsync();
            List<DepartmentDTO> departmentDTOs = departments.Select(department => _mapper.Map(department, new DepartmentDTO())).ToList();
            return departmentDTOs;
        }

        public virtual async Task<DepartmentDTO> GetIdAsync(int id)
        {
            var department = await unitOfWork.DepartmentRepo.GetByIdAsync(id);
            if (department == null)
                throw new Exception("Such order not found");
            var dto = new DepartmentDTO();
            _mapper.Map(department, dto);
            return dto;
        }

        public virtual async Task<DepartmentDTO> UpdateAsync(DepartmentDTO entity)
        {
            var value = new Department();
            _mapper.Map(entity, value);
            await unitOfWork.DepartmentRepo.UpdateAsync(value);
            return entity;
        }
    }
}
