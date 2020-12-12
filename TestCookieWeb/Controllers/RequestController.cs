using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCookieWeb.Core.Abstractions.IServices;
using TestCookieWeb.Core.DTO;
using TestCookieWeb.Core.Models;

namespace TestCookieWeb.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestController : ControllerBase
    {
        private IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDTO>>> Get()
        {
            var result = await _requestService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDTO>> getById(int id)
        {
            var result = await _requestService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RequestDTO>> Pull(RequestDTO order)
        {
            await _requestService.CreateAsync(order);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<RequestDTO>> Update(RequestDTO order)
        {
            var result = await _requestService.UpdateAsync(order);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requestService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("approve/{uid}")]
        public async Task<ActionResult<List<RequestDTO>>> GetApprove(int uid)
        {
            var result = await _requestService.GetAllApprove(uid);
            return Ok(result);
        }
    }
}
