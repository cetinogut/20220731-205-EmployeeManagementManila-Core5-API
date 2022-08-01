using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class EmployeeForUpdateDTO
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "Last Name can't be longer than 60 characters")]
        public string? LastName { get; set; }


        public DateTime DateOfBirth { get; set; }
    }
}
