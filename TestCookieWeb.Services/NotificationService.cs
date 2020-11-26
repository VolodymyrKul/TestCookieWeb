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
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(NotificationDTO entity)
        {
            var value = new Notification();
            _mapper.Map(entity, value);
            await unitOfWork.NotificationRepo.AddAsync(value);
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.NotificationRepo.GetByIdAsync(id);
            await unitOfWork.NotificationRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<NotificationDTO>> GetAll()
        {
            var notifications = await unitOfWork.NotificationRepo.GetAllAsync();
            List<NotificationDTO> notificationDTOs = notifications.Select(notification => _mapper.Map(notification, new NotificationDTO())).ToList();
            return notificationDTOs;
        }

        public virtual async Task<NotificationDTO> GetIdAsync(int id)
        {
            var notification = await unitOfWork.NotificationRepo.GetByIdAsync(id);
            if (notification == null)
                throw new Exception("Such order not found");
            var dto = new NotificationDTO();
            _mapper.Map(notification, dto);
            return dto;
        }

        public virtual async Task<NotificationDTO> UpdateAsync(NotificationDTO entity)
        {
            var value = new Notification();
            _mapper.Map(entity, value);
            await unitOfWork.NotificationRepo.UpdateAsync(value);
            return entity;
        }
    }
}
