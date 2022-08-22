using BLL.DTOs;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [EnableCors("CrosOriginPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("get-allemployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<EmployeeDto> employees = await _employeeService.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet]
        [Route("get-employee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            EmployeeDto employeeDTO = await _employeeService.GetEmployeeById(employeeId);
            return Ok(employeeDTO);
        }

        //[Authorize("Admin")]
        [HttpPost]
        [Route("create-employee")]
        public async Task<IActionResult> CreateEmployee(EmployeeDto employeeDto)
        {
            EmployeeDto employeeDTO = await _employeeService.CreateEmployee(employeeDto);

            return Ok(employeeDTO);
        }

        //[Authorize("Admin")]
        [HttpPut]
        [Route("update-employee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            EmployeeDto employeeDTO = await _employeeService.UpdateEmployee(employeeDto);
            if (employeeDTO == null)
                return BadRequest();

            return Ok(employeeDTO);
        }

        //[Authorize("Admin")]
        [HttpDelete]
        [Route("delete-employee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            bool employeeDTO = await _employeeService.DeleteEmployee(employeeId);

            return Ok(employeeDTO);
        }
    }
}
