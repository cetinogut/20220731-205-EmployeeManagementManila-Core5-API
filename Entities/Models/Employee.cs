using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("employee")]
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(60, ErrorMessage = "First Name can't be longer than 60 characters")]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters")]
        public string? Address { get; set; }

        public DateTime DateOfBirth { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}