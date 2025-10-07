using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BLL.DTOs;
using WorkHub.BLL.Result_Pattern;
using WorkHub.DAL.Models;

namespace WorkHub.BLL.ServiceInterface
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
