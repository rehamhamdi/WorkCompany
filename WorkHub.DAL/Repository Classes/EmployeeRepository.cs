using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.DAL.Context;
using WorkHub.DAL.Models;
using WorkHub.DAL.Repository_Interfaces;
using AppContext = WorkHub.DAL.Context.AppContext;

namespace WorkHub.DAL.Repository_Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Getting all employees from database");
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            
            return await _context.Employees.FindAsync(employeeId);

        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
