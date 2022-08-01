using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("account")]
    public class Account
    {
        [Column("AccountId")]
        public Guid Id { get; set; }
        //public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}