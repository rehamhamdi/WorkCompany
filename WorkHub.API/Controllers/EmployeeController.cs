using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WorkHub.BLL.DTOs;
using WorkHub.BLL.ServiceInterface;

namespace WorkHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService empservice,ILogger<EmployeeController> looger)
        {
            _service = empservice;
            _logger = looger;
        }
        [HttpGet] //Get: api/Employee
        public async Task<ActionResult> GetAll()
        {
            _logger.LogInformation("Request Get all employees from Employee Controller");
            var emps= await _service.GetAllEmployeesAsync();
            _logger.LogInformation("All Employess returned Successfully");
            return Ok(emps);
        }

        [HttpGet("{id:int}")]//Get: api/Employee/{id}
        public async Task<ActionResult> GetById(int id)
        {
            _logger.LogInformation("Recieve request to get the info of employee with id= {id} ",id);
            var result= await _service.GetEmployeeByIdAsync(id);
            if(!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost] //POST:  api/Employee
        public async Task<ActionResult> AddEmployee(EmployeeDTO emp)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.AddEmployeeAsync(emp);
            _logger.LogInformation("{@emp} added to employees Successfully ", emp);
            return Created("Added Successfully", emp);
        }

        [HttpPut("{id:int}")] //PUT: api/Employee
        public async Task<ActionResult> UpdateEmployee(EmployeeDTO emp, int id)
        { 
           var result= await _service.UpdateEmployeeAsync(emp,id);
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
