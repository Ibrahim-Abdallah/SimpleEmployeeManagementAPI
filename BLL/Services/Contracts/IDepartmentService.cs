using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentDto);
        Task<bool> DeleteDepartment(int id);
    }
}
