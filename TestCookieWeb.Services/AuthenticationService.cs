using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.Models;
using TestCookieWeb.Services.Base;
using CryptoHelper;
using System.Security.Claims;
using TestCookieWeb.Services.Helpers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TestCookieWeb.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<string> GetAccessTokenAsync(User user)
        {
            var claimsIdentity = await GetClaimsIdentityAsync(user);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: "TestCookieServer",
                audience: "TestCookieClient",
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(AuthHelper.GetSymmetricSecurityKey("testcookie_secretkey!!!"),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<string> RefreshUserTokenAsync(int userId, string oldRefreshToken)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(userId);

            if (user.RefreshToken != oldRefreshToken)
            {
                return null;
            }

            return await GetAccessTokenAsync(user);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentityAsync(User userEntity)
        {
            var users = await unitOfWork.UserRepo.GetAllAsync();
            var user = users.Where(u => u.Email == userEntity.Email && u.Password == userEntity.Password).FirstOrDefault();

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.IdUserRoleNavigation.Title),
                    new Claim(AuthHelper.RefreshToken, user.RefreshToken)
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
