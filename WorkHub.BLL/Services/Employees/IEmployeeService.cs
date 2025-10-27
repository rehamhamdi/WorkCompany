using WorkHub.BLL.DTOs;
using WorkHub.BLL.Result_Pattern;

namespace WorkHub.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<Result<EmployeeDTO>> GetEmployeeByIdAsync(int employeeId);
        Task AddEmployeeAsync(EmployeeDTO employeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<Result<EmployeeDTO>> UpdateEmployeeAsync(EmployeeDTO employeeDto, int id);
    }
}
