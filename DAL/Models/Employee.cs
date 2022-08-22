using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public bool isActive { get; set; }
    }
}
