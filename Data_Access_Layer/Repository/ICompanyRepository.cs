using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repository
{
    public interface ICompanyRepository
	{
		Task<IEnumerable<Company>> GetAllCompanyAsync();
		Task<Company?> GetCompanyByIdAsync(Guid id);
		Task<Company> CreateCompanyAsync(Company company);
		Task<Company?> UpdateCompanyAsync(Guid id, Company company);
		Task<Company?> DeleteCompanyAsync(Guid id);
	}
}
