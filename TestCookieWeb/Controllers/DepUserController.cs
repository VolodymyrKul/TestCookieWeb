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
    [Route("api/depusers")]
    public class DepUserController : ControllerBase
    {
        private IDepUserService _depUserService;

        public DepUserController(IDepUserService depUserService)
        {
            _depUserService = depUserService;
        }

        [HttpGet]
        public ActionResult<List<DepUserDTO>> Get()
        {
            var result = _depUserService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<DepUserDTO> getById(int id)
        {
            var result = _depUserService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<DepUserDTO> Pull(DepUserDTO order)
        {
            return Ok(_depUserService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<DepUserDTO> Update(DepUserDTO order)
        {
            return Ok(_depUserService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _depUserService.DeleteAsync(id);
            return NoContent();
        }
    }
}
