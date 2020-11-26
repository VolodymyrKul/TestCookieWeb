using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.DTO;

namespace TestCookieWeb.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public ActionResult<List<NotificationDTO>> Get()
        {
            var result = _notificationService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<NotificationDTO> getById(int id)
        {
            var result = _notificationService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<NotificationDTO> Pull(NotificationDTO order)
        {
            return Ok(_notificationService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<NotificationDTO> Update(NotificationDTO order)
        {
            return Ok(_notificationService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _notificationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
