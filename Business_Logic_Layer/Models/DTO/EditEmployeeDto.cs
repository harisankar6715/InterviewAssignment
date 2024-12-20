using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models.DTO
{
	public class EditEmployeeDto
	{
		[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabets and spaces are allowed.")]
		public string Name { get; set; }
		public string ContactNo { get; set; }
		public string? Address { get; set; }
		public Guid CompanyId { get; set; }
	}
}
