using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models.DTO
{
	public class AddCompanyDto
	{
		[Required, MaxLength(10), RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
		public string Code { get; set; }
		[Required, MaxLength(50), RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Only alphabets and spaces are allowed.")]
		public string Name { get; set; }
		public string? Address { get; set; }
	}
}
