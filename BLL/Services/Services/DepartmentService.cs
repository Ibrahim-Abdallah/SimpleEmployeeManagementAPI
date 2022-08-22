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
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        public DepartmentService(IWrapperRepository wrapperRepository) : base(wrapperRepository)
        {
        }

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto departmentDto)
        {
            Department department = new Department
            {
                Name = departmentDto.Name
            };

            await _wrapperRepository.Departments.CreateAsync(department);
            await _wrapperRepository.SaveAsync();

            DepartmentDto departmentDTO = OMapper.Mapper.Map<DepartmentDto>(department);
            return departmentDTO;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            Department? department = await _wrapperRepository.Departments.GetByIdAsync(id);
            if (department == null)
                return false;

            _wrapperRepository.Departments.Delete(department);
            _wrapperRepository.Save();

            return true;
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            IQueryable<Department> departments = await _wrapperRepository.Departments.GetAll();
            List<DepartmentDto> departmentsDTO = OMapper.Mapper.Map<List<DepartmentDto>>(departments);

            return departmentsDTO;
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            Department? department = await _wrapperRepository.Departments.GetByIdAsync(id);
            if (department == null)
                return new DepartmentDto();

            DepartmentDto departmentDTO = OMapper.Mapper.Map<DepartmentDto>(department);
            return departmentDTO;
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentDto)
        {
            Department? department = await _wrapperRepository.Departments.GetByIdAsync(departmentDto.Id);
            
            department.Name = departmentDto.Name;

            _wrapperRepository.Departments.Update(department);
            await _wrapperRepository.SaveAsync();

            DepartmentDto departmentDTO = OMapper.Mapper.Map<DepartmentDto>(department);
            return departmentDTO;
        }
    }
}
