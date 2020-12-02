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
        public async Task<ActionResult<List<DepUserDTO>>> Get()
        {
            var result = await _depUserService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepUserDTO>> getById(int id)
        {
            var result = await _depUserService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepUserDTO>> Pull(DepUserDTO order)
        {
            await _depUserService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<DepUserDTO>> Update(DepUserDTO order)
        {
            var result = await _depUserService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _depUserService.DeleteAsync(id);
            return NoContent();
        }
    }
}
