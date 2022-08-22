using BLL.DTOs;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Authorize("Admin")]
    [EnableCors("CrosOriginPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("get-alldepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            List<DepartmentDto> departments = await _departmentService.GetAllDepartments();

            return Ok(departments);
        }

        [HttpGet]
        [Route("get-department/{departmentId}")]
        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            DepartmentDto departmentDTO = await _departmentService.GetDepartmentById(departmentId);
            return Ok(departmentDTO);
        }

        [HttpPost]
        [Route("create-department")]
        public async Task<IActionResult> CreateDepartment(DepartmentDto departmentDto)
        {
            DepartmentDto departmentDTO = await _departmentService.CreateDepartment(departmentDto);

            return Ok(departmentDTO);
        }

        [HttpPut]
        [Route("update-department")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto departmentDto)
        {
            DepartmentDto departmentDTO = await _departmentService.UpdateDepartment(departmentDto);
            if (departmentDTO == null)
                return BadRequest();

            return Ok(departmentDTO);
        }

        [HttpDelete]
        [Route("delete-department/{departmentId}")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            bool departmentDTO = await _departmentService.DeleteDepartment(departmentId);

            return Ok(departmentDTO);
        }
    }
}
