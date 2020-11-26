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
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.RequestRepo.GetByIdAsync(id);
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
    }
}
