using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public bool isActive { get; set; }
    }
}
