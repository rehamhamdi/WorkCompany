using Microsoft.AspNetCore.Mvc;
using WorkHub.BLL.DTOs;
using WorkHub.BLL.ServiceInterface;

namespace WorkHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService empservice)
        {
            _service = empservice;
        }
        [HttpGet] //Get: api/Employee
        public async Task<ActionResult> GetAll()
        {
            var emps = await _service.GetAllEmployeesAsync();
            return Ok(emps);
        }

        [HttpGet("{id:int}")]//Get: api/Employee/{id}
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _service.GetEmployeeByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost] //POST:  api/Employee
        public async Task<ActionResult> AddEmployee(EmployeeDTO emp)
        {
            await _service.AddEmployeeAsync(emp);
            return Created("Added Successfully", emp);
        }

        [HttpPut("{id:int}")] //PUT: api/Employee
        public async Task<ActionResult> UpdateEmployee(EmployeeDTO emp, int id)
        {
            var result = await _service.UpdateEmployeeAsync(emp, id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpDelete] //Delete:  api/Employee
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return Ok("Deleted Successfully");
        }

    }
}
