using AutoMapper;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Core.Models;
using TestCookieWeb.Services.Helpers;

namespace TestCookieWeb.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [ResponseCache(NoStore = true)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserDTO userDTO)
        {
            try
            {
                //var user = _mapper.Map<User>(userDTO);

                await _userService.CreateAsync(userDTO);

                //logger.LogInformation($"User register. Id: {user.Id}");

                return Ok();
            }
            catch (DbUpdateException exc)
            {
                //logger.LogError(exc, exc.Message);
                return BadRequest("User with specified email already exists.");
            }
        }

        [HttpPost("login")]
        [ResponseCache(NoStore = true)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync([FromBody] UserDTO userDTO)
        {
            var user = await _userService.GetUserByCredentialsAsync(userDTO.Email, userDTO.Password);

            if (user == null)
            {
                var message = "Invalid user`s login or password.";

                //logger.LogInformation(message);
                return BadRequest(message);
            }

            var accessToken = await _authenticationService.GetAccessTokenAsync(user);

            //logger.LogInformation($"User log in. Id: {user.Id}");

            return Ok(new
            {
                User = _mapper.Map<UserDTO>(user),
                AccessToken = accessToken
            });
        }

        [HttpPost("refresh")]
        [ResponseCache(NoStore = true)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshUserTokenAsync()
        {
            var refreshToken = User.FindFirst(x => x.Type == AuthHelper.RefreshToken)?.Value;

            if (refreshToken == null)
            {
                var message = "There is no refresh token for specified user.";
                //logger.LogInformation(message);

                return BadRequest(message);
            }

            var userId = AuthHelper.GetUserId(User);
            var user = await _userService.GetIdAsync(userId);

            if (user == null)
            {
                var message = "Specified user is not registered.";
                //logger.LogInformation(message);

                return BadRequest(message);
            }

            var accessToken = await _authenticationService.RefreshUserTokenAsync(userId, refreshToken);

            return Ok(new
            {
                User = _mapper.Map<UserDTO>(user),
                AccessToken = accessToken
            });
        }
    }
}
