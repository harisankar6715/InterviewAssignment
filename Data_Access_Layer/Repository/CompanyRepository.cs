using Demo.DAL.Entity;
using Demo.DAL.SharedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Demo.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository
	{
		public async Task<Company> CreateCompanyAsync(Company company)
		{
			company.Id = Guid.NewGuid();
			await Task.Run(() => DataSource.company.Add(company));
			return company;
		}

		public async Task<Company?> DeleteCompanyAsync(Guid id)
		{
			var company = DataSource.company.FirstOrDefault(x => x.Id == id);
			if (company != null)
			{
				await Task.Run(() => DataSource.company.Remove(company));
			}
			return company;
		}

		public async Task<IEnumerable<Company>> GetAllCompanyAsync()
		{
			return await Task.Run(() => DataSource.company);
		}

		public async Task<Company?> GetCompanyByIdAsync(Guid id)
		{
			return await Task.Run(() => DataSource.company.FirstOrDefault(x => x.Id == id));
		}

		public async Task<Company?> UpdateCompanyAsync(Guid id, Company company)
		{
			var existingCompany = await Task.FromResult(DataSource.company.FirstOrDefault(x => x.Id == id));

			if (existingCompany != null)
			{
				await Task.Run(() => DataSource.company.Where(x => x.Id == id).ToList().ForEach(x =>
				{
					x.Code = existingCompany.Code;
					x.Name = company.Name;
					x.Address = company.Address;
				}));
			}
			return existingCompany;
		}
	}
}
