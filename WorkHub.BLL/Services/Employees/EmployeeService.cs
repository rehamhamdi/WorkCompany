using AutoMapper;
using Microsoft.Extensions.Logging;
using WorkHub.BLL.DTOs;
using WorkHub.BLL.Result_Pattern;
using WorkHub.DAL.Models;
using WorkHub.DAL.Repositories;

namespace WorkHub.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddEmployeeAsync(EmployeeDTO employeeDto)
        {

            var employee = _mapper.Map<Employee>(employeeDto);
            await _repo.AddEmployeeAsync(employee);
            _logger.LogInformation("{@emp} added to employees Successfully ", employeeDto);

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repo.DeleteEmployeeAsync(id);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Starting getting all employees");
            var emps = await _repo.GetAllEmployeesAsync();
            var empsDto = _mapper.Map<List<EmployeeDTO>>(emps);
            _logger.LogInformation("All Employess returned Successfully");
            return empsDto;
        }

        public async Task<Result<EmployeeDTO>> GetEmployeeByIdAsync(int employeeId)
        {
            _logger.LogInformation("Recieve request to get the info of employee with id= {id} ", employeeId);
            var employee = await _repo.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return Result<EmployeeDTO>.Fail("Employee not found");
            }
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);

            return Result<EmployeeDTO>.Ok(employeeDto, "Employee found Successfully");
        }

        public async Task<Result<EmployeeDTO>> UpdateEmployeeAsync(EmployeeDTO Updatedemp, int id)
        {
            var emp = await _repo.GetEmployeeByIdAsync(id);
            if (emp == null)
            {
                return Result<EmployeeDTO>.Fail("Employee not found");
            }
            _mapper.Map(Updatedemp, emp);
            await _repo.UpdateEmployeeAsync(emp);
            return Result<EmployeeDTO>.Ok(Updatedemp, "Employee Updated Successfully");
        }
    }
}
