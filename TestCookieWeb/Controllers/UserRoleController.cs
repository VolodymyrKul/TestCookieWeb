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
    [Route("api/userroles")]
    public class UserRoleController : ControllerBase
    {
        private IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRoleDTO>>> Get()
        {
            var result = await _userRoleService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDTO>> getById(int id)
        {
            var result = await _userRoleService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleDTO>> Pull(UserRoleDTO order)
        {
            await _userRoleService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<UserRoleDTO>> Update(UserRoleDTO order)
        {
            var result = await _userRoleService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRoleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
