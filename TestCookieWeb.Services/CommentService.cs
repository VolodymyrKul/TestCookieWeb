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
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CommentDTO entity)
        {
            var value = new Comment();
            _mapper.Map(entity, value);
            await unitOfWork.CommentRepo.AddAsync(value);
            //unitOfWork.SaveChanges();
            //entity.Id = value.Id;
            //return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await unitOfWork.CommentRepo.GetByIdAsync(id);
            await unitOfWork.CommentRepo.DeleteAsync(entity);
            //unitOfWork.SaveChanges();
        }

        public virtual async Task<List<CommentDTO>> GetAll()
        {
            var comments = await unitOfWork.CommentRepo.GetAllAsync();
            List<CommentDTO> commentDTOs = comments.Select(comment => _mapper.Map(comment, new CommentDTO())).ToList(); ;
            return commentDTOs;
        }

        public virtual async Task<CommentDTO> GetIdAsync(int id)
        {
            var comment = await unitOfWork.CommentRepo.GetByIdAsync(id);
            if (comment == null)
                throw new Exception("Such order not found");
            var dto = new CommentDTO();
            _mapper.Map(comment, dto);
            return dto;
        }

        public virtual async Task<CommentDTO> UpdateAsync(CommentDTO entity)
        {
            var value = new Comment();
            _mapper.Map(entity, value);
            await unitOfWork.CommentRepo.UpdateAsync(value);
            return entity;
        }
    }
}
