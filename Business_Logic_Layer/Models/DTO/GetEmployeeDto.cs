using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models.DTO
{
	public class GetEmployeeDto
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ContactNo { get; set; }
		public string? Address { get; set; }
		public Guid CompanyId { get; set; }
		public Company Company { get; set; }
	}
}
