using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repository
{
    public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetAllEmployeeAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
		Task<Employee?> GetEmployeeByIdAsync(Guid id);
		Task<Employee> CreateEmployeeAsync(Employee Employee);
		Task<Employee?> UpdateEmployeeAsync(Guid id, Employee Employee);
		Task<Employee?> DeleteEmployeeAsync(Guid id);
	}
}
