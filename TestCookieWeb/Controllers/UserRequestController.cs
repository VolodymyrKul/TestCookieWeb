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
        public async Task<ActionResult<List<UserRequestDTO>>> Get()
        {
            var result = await _userRequestService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRequestDTO>> getById(int id)
        {
            var result = await _userRequestService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserRequestDTO>> Pull(UserRequestDTO order)
        {
            await _userRequestService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UserRequestDTO>> Update(UserRequestDTO order)
        {
            var result = await _userRequestService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRequestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
