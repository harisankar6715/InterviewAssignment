using Demo.API.CustomActionFilters;
using Demo.BLL.Models.DTO;
using Demo.BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeBLL;
		public EmployeeController(IEmployeeService employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllEmployee([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending)
		{
			var data = await _employeeBLL.GetAllEmployeeAsync(filterOn, filterQuery, sortBy, isAscending ?? true);
			return Ok(data);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
		{
			var data = await _employeeBLL.GetEmployeeByIdAsync(id);
			return Ok(data);
		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> CreateCompany([FromBody] AddEmployeeDto addEmployeeDto)
		{
			var data = await _employeeBLL.CreateEmployeeAsync(addEmployeeDto);
			return Ok(data);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteEmployeeById([FromRoute] Guid id)
		{
			var data = await _employeeBLL.DeleteEmployeeAsync(id);
			return Ok(data);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		[ValidateModel]
		public async Task<IActionResult> UpdateEmployeeById([FromRoute] Guid id, [FromBody] EditEmployeeDto editEmployeeDto)
		{
			var data = await _employeeBLL.UpdateEmployeeAsync(id, editEmployeeDto);
			return Ok(data);
		}
	}
}
