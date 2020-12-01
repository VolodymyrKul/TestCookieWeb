using AutoMapper;
using CryptoHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Services.Helpers;

namespace TestCookieWeb.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            
            var result = await _userService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> getById(int id)
        {
            var result = await _userService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Pull(UserDTO order)
        {
            List<UserDTO> users  = await _userService.GetAll();
            var result = users.FirstOrDefault(u => u.Email == order.Email);
            if (result == null)
            {
                await _userService.CreateAsync(order);
                return Ok(order);
            }
            else
            {
                return BadRequest("User already is in database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO order)
        {
            var result = await _userService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("info")]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Any,
            VaryByHeader = "Authorization",
            Duration = 60)]
        public async Task<ActionResult<UserDTO>> GetUserInfo()
        {
            var userViewModel = await GetCurrentUserAsync();

            if (userViewModel == null)
            {
                return BadRequest();
            }

            return Ok(userViewModel);
        }

        private async Task<UserDTO> GetCurrentUserAsync()
        {
            var userId = AuthHelper.GetUserId(User);

            var user = await _userService.GetIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var userViewModel = _mapper.Map<UserDTO>(user);

            return userViewModel;
        }
    }
}
