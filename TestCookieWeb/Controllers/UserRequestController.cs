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
    [Route("api/userrequests")]
    public class UserRequestController : ControllerBase
    {
        private IUserRequestService _userRequestService;

        public UserRequestController(IUserRequestService userRequestService)
        {
            _userRequestService = userRequestService;
        }

        [HttpGet]
        public ActionResult<List<UserRequestDTO>> Get()
        {
            var result = _userRequestService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<UserRequestDTO> getById(int id)
        {
            var result = _userRequestService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<UserRequestDTO> Pull(UserRequestDTO order)
        {
            return Ok(_userRequestService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<UserRequestDTO> Update(UserRequestDTO order)
        {
            return Ok(_userRequestService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRequestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
