using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Practial.Domain.Models
{
    public class Club
    {
        [Key]
        public char ClubId { get; set; }

        public string Name { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
