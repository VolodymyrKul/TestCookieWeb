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
        public ActionResult<List<RequestDTO>> Get()
        {
            var result = _requestService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<RequestDTO> getById(int id)
        {
            var result = _requestService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<RequestDTO> Pull(RequestDTO order)
        {
            _requestService.CreateAsync(order);
            return Ok(_requestService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<RequestDTO> Update(RequestDTO order)
        {
            return Ok(_requestService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _requestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
