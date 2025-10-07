using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.DAL.Models;

namespace WorkHub.DAL.Repository_Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
