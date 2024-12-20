using Demo.DAL.Entity;
using Demo.DAL.SharedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
	{
		public async Task<Employee> CreateEmployeeAsync(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			await Task.Run(() => DataSource.employees.Add(employee));
			return employee;
		}

		public async Task<Employee?> DeleteEmployeeAsync(Guid id)
		{
			var employee = DataSource.employees.FirstOrDefault(e => e.Id == id);
			if (employee != null)
			{
				await Task.Run(() => DataSource.employees.Remove(employee));
			}
			return employee;
		}

		public async Task<IEnumerable<Employee>> GetAllEmployeeAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
		{
			return await Task.Run(() =>
			{
				var employees = DataSource.employees;
				var companies = DataSource.company;
				foreach (var employee in employees)
				{
					employee.Company = companies.FirstOrDefault(c => c.Id == employee.CompanyId);
				}
				//Filtering
				if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
				{
					filterQuery = filterQuery.Trim();
					if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
					{
						employees = employees.Where(x => x.Name.Contains(filterQuery, StringComparison.OrdinalIgnoreCase)).ToList();
					}
				}
				//Sorting
				if (!string.IsNullOrWhiteSpace(sortBy))
				{
					sortBy = sortBy.Trim();
					employees = sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)
						? (isAscending ? employees.OrderBy(x => x.Name).ToList() : employees.OrderByDescending(x => x.Name).ToList())
						: employees;
				}
				return employees;
			});
		}

		public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
		{
			return await Task.Run(() =>
			{
				var employees = DataSource.employees;
				var companies = DataSource.company;
				var employee = employees.FirstOrDefault(e => e.Id == id);
				if (employee != null)
				{
					employee.Company = companies.FirstOrDefault(c => c.Id == employee.CompanyId);
				}
				return employee;
			});
		}

		public async Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee)
		{
			var existingEmployee = await Task.FromResult(DataSource.employees.FirstOrDefault(e => e.Id == id));
			if (existingEmployee != null)
			{
				await Task.Run(() => 
				{
					existingEmployee.Code = existingEmployee.Code;
					existingEmployee.Name = employee.Name;
					existingEmployee.ContactNo = employee.ContactNo;
					existingEmployee.Address = employee.Address;
					existingEmployee.CompanyId = employee.CompanyId;
				});
			}
			return existingEmployee;
		}
	}
}
