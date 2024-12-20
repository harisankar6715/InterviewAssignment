using Demo.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Service
{
    public interface ICompanyService
	{
		Task<IEnumerable<GetCompanyDto>> GetAllCompanyAsync();
		Task<GetCompanyDto?> GetCompanyByIdAsync(Guid id);
		Task<AddCompanyDto> CreateCompanyAsync(AddCompanyDto addCompanyDto);
		Task<EditCompanyDto?> UpdateCompanyAsync(Guid id, EditCompanyDto editCompanyDto);
		Task<GetCompanyDto> DeleteCompanyAsync(Guid id);
	}
}
