using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practial.Domain.Models
{
    public class Department
    {
        [Key]
        public char DepartmentId { get; set; }

        public string Name { get; set; }

        public decimal AnnualBudget { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
