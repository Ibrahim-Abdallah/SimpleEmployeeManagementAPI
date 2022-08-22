using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
        Task<bool> DeleteEmployee(int id);
    }
}
