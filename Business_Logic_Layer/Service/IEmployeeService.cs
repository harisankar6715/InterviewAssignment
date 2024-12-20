using Demo.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Service
{
	public interface IEmployeeService
	{
		Task<IEnumerable<GetEmployeeDto>> GetAllEmployeeAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
		Task<GetEmployeeDto?> GetEmployeeByIdAsync(Guid id);
		Task<AddEmployeeDto> CreateEmployeeAsync(AddEmployeeDto addEmployeeDto);
		Task<EditEmployeeDto?> UpdateEmployeeAsync(Guid id, EditEmployeeDto editEmployeeDto);
		Task<GetEmployeeDto> DeleteEmployeeAsync(Guid id);
	}
}
