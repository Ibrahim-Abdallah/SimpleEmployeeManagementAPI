using DAL.Models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Repositories
{
    public class WrapperRepository : IWrapperRepository
    {
        private readonly ApplicationDbContext _context;
        private IDepartmentRepository _departments;
        private IEmployeeRepository _employees;

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new EmployeeRepository(_context);
                }
                return _employees;
            }
        }

        public WrapperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
