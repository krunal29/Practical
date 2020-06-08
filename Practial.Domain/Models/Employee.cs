using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practial.Domain.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Club")]
        public char ClubId { get; set; }

        public Club Club { get; set; }

        [ForeignKey("Department")]
        public char DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
