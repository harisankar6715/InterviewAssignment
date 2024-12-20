using AutoMapper;
using Demo.BLL.Models.DTO;
using Demo.DAL.Entity;
using Demo.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

		public async Task<IEnumerable<GetCompanyDto>> GetAllCompanyAsync()
		{
			IEnumerable<Company> companies = await Task.Run(() => _companyRepository.GetAllCompanyAsync());
			IEnumerable<GetCompanyDto> getCompanyDtos = _mapper.Map<IEnumerable<Company>, IEnumerable<GetCompanyDto>>(companies);
			return getCompanyDtos;
		}

		public async Task<GetCompanyDto?> GetCompanyByIdAsync(Guid id)
		{
			var company = await Task.Run(() => _companyRepository.GetCompanyByIdAsync(id));
			return company == null ? null : _mapper.Map<Company, GetCompanyDto>(company);
		}

		public async Task<AddCompanyDto> CreateCompanyAsync(AddCompanyDto addCompanyDto)
		{
			Company company = _mapper.Map<AddCompanyDto, Company>(addCompanyDto);
			await Task.FromResult(_companyRepository.CreateCompanyAsync(company));
			return addCompanyDto;
		}

		public async Task<EditCompanyDto?> UpdateCompanyAsync(Guid id, EditCompanyDto editCompanyDto)
		{
			var company = _mapper.Map<EditCompanyDto, Company>(editCompanyDto);
			var data = await Task.FromResult(_companyRepository.UpdateCompanyAsync(id, company));
			return data == null ? null : editCompanyDto;
		}

		public async Task<GetCompanyDto> DeleteCompanyAsync(Guid id)
		{
			var company = await Task.Run(() => _companyRepository.DeleteCompanyAsync(id));
			return company == null ? null : _mapper.Map<Company, GetCompanyDto>(company);
		}
	}
}
