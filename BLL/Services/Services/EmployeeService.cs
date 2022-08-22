using BLL.AutoMapperConfig;
using BLL.DTOs;
using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IWrapperRepository wrapperRepository) : base(wrapperRepository)
        {
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                Name = employeeDto.Name,
                DepartmentId = employeeDto.DepartmentId,
                isActive = employeeDto.isActive,
                Salary = employeeDto.Salary
            };

            await _wrapperRepository.Employees.CreateAsync(employee);
            await _wrapperRepository.SaveAsync();

            EmployeeDto employeeDTO = OMapper.Mapper.Map<EmployeeDto>(employee);
            return employeeDTO;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee? employee = await _wrapperRepository.Employees.GetByIdAsync(id);
            if (employee == null)
                return false;

            _wrapperRepository.Employees.Delete(employee);
            _wrapperRepository.Save();

            return true;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            IQueryable<Employee> employees = await _wrapperRepository.Employees.GetAllIncludingDepartment();
            List<EmployeeDto> employeesDTO = OMapper.Mapper.Map<List<EmployeeDto>>(employees);

            return employeesDTO;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            Employee? employee = await _wrapperRepository.Employees.GetByIdAsync(id);
            if (employee == null)
                return new EmployeeDto();

            EmployeeDto employeeDTO = OMapper.Mapper.Map<EmployeeDto>(employee);
            return employeeDTO;
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            Employee? employee = await _wrapperRepository.Employees.GetByIdAsync(employeeDto.Id);

            employee.Name = employeeDto.Name;
            employee.DepartmentId = employeeDto.DepartmentId;
            employee.isActive = employeeDto.isActive;
            employee.Salary = employeeDto.Salary;

            _wrapperRepository.Employees.Update(employee);
            await _wrapperRepository.SaveAsync();

            EmployeeDto employeeDTO = OMapper.Mapper.Map<EmployeeDto>(employee);
            return employeeDTO;
        }
    }
}
