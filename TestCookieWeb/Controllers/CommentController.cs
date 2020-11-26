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
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<List<CommentDTO>> Get()
        {
            var result = _commentService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> getById(int id)
        {
            var result = await _commentService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<CommentDTO> Pull(CommentDTO order)
        {
            return Ok(_commentService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<CommentDTO> Update(CommentDTO order)
        {
            return Ok(_commentService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
