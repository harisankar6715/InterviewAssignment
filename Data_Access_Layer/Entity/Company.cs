using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    public class Company
    {
        [Key, Required]
        public Guid Id { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string? Address { get; set; }
    }
}
