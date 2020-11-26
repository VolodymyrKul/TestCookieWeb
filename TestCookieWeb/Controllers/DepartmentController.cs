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
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<List<DepartmentDTO>> Get()
        {
            var result = _departmentService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> getById(int id)
        {
            var result = _departmentService.GetIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<DepartmentDTO> Pull(DepartmentDTO order)
        {
            return Ok(_departmentService.CreateAsync(order));
        }

        [HttpPut]
        public ActionResult<DepartmentDTO> Update(DepartmentDTO order)
        {
            return Ok(_departmentService.UpdateAsync(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _departmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
