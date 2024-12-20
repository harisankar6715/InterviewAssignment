using AutoMapper;
using Demo.BLL.Models.DTO;
using Demo.DAL.Entity;
using Demo.DAL.Repository;

namespace Demo.BLL.Service
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
			_mapper = mapper;
        }

        public async Task<AddEmployeeDto> CreateEmployeeAsync(AddEmployeeDto addEmployeeDto)
		{
			Employee employee = _mapper.Map<AddEmployeeDto, Employee>(addEmployeeDto);
			await Task.FromResult(_employeeRepository.CreateEmployeeAsync(employee));
			return addEmployeeDto;
		}

		public async Task<GetEmployeeDto> DeleteEmployeeAsync(Guid id)
		{
			var employee = await Task.Run(() => _employeeRepository.DeleteEmployeeAsync(id));
			return employee == null ? null : _mapper.Map<Employee, GetEmployeeDto>(employee);
		}

		public async Task<IEnumerable<GetEmployeeDto>> GetAllEmployeeAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
		{
			IEnumerable<Employee> employee = await Task.Run(() => _employeeRepository.GetAllEmployeeAsync(filterOn, filterQuery, sortBy, isAscending));
			IEnumerable<GetEmployeeDto> getEmployeeDtos = _mapper.Map<IEnumerable<Employee>, IEnumerable<GetEmployeeDto>>(employee);
			return getEmployeeDtos;
		}

		public async Task<GetEmployeeDto?> GetEmployeeByIdAsync(Guid id)
		{
			var employee = await Task.Run(() => _employeeRepository.GetEmployeeByIdAsync(id));
			return employee == null ? null : _mapper.Map<Employee, GetEmployeeDto>(employee);
		}

		public async Task<EditEmployeeDto?> UpdateEmployeeAsync(Guid id, EditEmployeeDto editEmployeeDto)
		{
			var employee = _mapper.Map<EditEmployeeDto, Employee>(editEmployeeDto);
			var data = await Task.FromResult(_employeeRepository.UpdateEmployeeAsync(id, employee));
			return data == null ? null : editEmployeeDto;
		}
	}
}
