using AutoMapper;
using CryptoHelper;
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
using TestCookieWeb.Services.Helpers;

namespace TestCookieWeb.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public virtual async Task CreateAsync(UserDTO entity)
        {
            entity.Password = RC5Helper.HashMes(entity.Password);
            entity.RefreshToken = GenerateRefreshToken();
            var value = new User();
            _mapper.Map(entity, value);
            await unitOfWork.UserRepo.AddAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.UserRepo.GetByIdAsync(id);
            await unitOfWork.UserRepo.DeleteAsync(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UserDTO>> GetAll()
        {
            var users = await unitOfWork.UserRepo.GetAllAsync();
            List<UserDTO> userDTOs = users.Select(user => _mapper.Map(user, new UserDTO())).ToList();
            foreach(UserDTO item in userDTOs)
            {
                item.Password = RC5Helper.GetStartMes(item.Password);
            }
            return userDTOs;
        }

        public virtual async Task<UserDTO> GetIdAsync(int id)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Such order not found");
            var dto = new UserDTO();
            _mapper.Map(user, dto);
            dto.Password = RC5Helper.GetStartMes(dto.Password);
            return dto;
        }

        public virtual async Task<UserDTO> UpdateAsync(UserDTO entity)
        {
            var value = new User();
            entity.Password = RC5Helper.GetStartMes(entity.Password);
            _mapper.Map(entity, value);
            await unitOfWork.UserRepo.UpdateAsync(value);
            await unitOfWork.SaveChangesAsync();
            return entity;
        }

        private string GenerateRefreshToken()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return Base64Encode(new string(Enumerable.Repeat(chars, 25)
                .Select(s => s[random.Next(s.Length)]).ToArray()));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }

        public async Task<User> GetUserByCredentialsAsync(string email, string password)
        {
            var users = await unitOfWork.UserRepo.GetAllAsync();
            var user = users.Where(u => u.Email == email).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            //Special for admin
            //-------------------------------------------------
            //if (user.Email == DbColumnConstraints.AdminEmail &&
            //   user.Password == DbColumnConstraints.AdminPass)
            //{
            //    return user;
            //}
            //-------------------------------------------------
            //return user;
            return RC5Helper.VerifyHash(user.Password, password) ? user : null;
        }
    }
}
