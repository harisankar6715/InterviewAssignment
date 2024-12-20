using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    public class Employee
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required, Phone, MinLength(10), MaxLength(13)]
        public string ContactNo { get; set; }
        public string? Address { get; set; }
        [ForeignKey("Company"), Required]
        public Guid CompanyId { get; set; }
        //Navigation Property
        public Company Company { get; set; }
    }
}
