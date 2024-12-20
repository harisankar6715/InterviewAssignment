using AutoMapper;
using Demo.API.CustomActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.BLL.Service;
using Demo.BLL.Models.DTO;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyBLL;

        public CompanyController(ICompanyService company_BLL)
        {
            _companyBLL = company_BLL;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllCompany()
		{
			var data = await _companyBLL.GetAllCompanyAsync();
			return Ok(data);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetCompanyById([FromRoute] Guid id)
		{
			var data = await _companyBLL.GetCompanyByIdAsync(id);
			return Ok(data);
		}

		[HttpPost]
		[ValidateModel]
		public async Task<IActionResult> CreateCompany([FromBody] AddCompanyDto addCompanyDto)
		{
			var data = await _companyBLL.CreateCompanyAsync(addCompanyDto);
			return Ok(data);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteCompanyById([FromRoute] Guid id)
		{
			var data = await _companyBLL.DeleteCompanyAsync(id);
			return Ok(data);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		[ValidateModel]
		public async Task<IActionResult> UpdateCompanyById([FromRoute] Guid id, [FromBody] EditCompanyDto editCompanyDto)
		{
			var data = await _companyBLL.UpdateCompanyAsync(id, editCompanyDto);
			return Ok(data);
		}
	}
}
