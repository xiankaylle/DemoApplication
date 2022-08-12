using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeAPIController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost(template: nameof(AddEmployee), Name = nameof(AddEmployee))]
        public IActionResult AddEmployee([FromBody] EmployeeTransport employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            _employeeService.Add(employee);

            return CreatedAtRoute("Get", new { Id = employee.Id }, employee);
        }
        [HttpPatch(template: nameof(UpdateEmployee), Name = nameof(UpdateEmployee))]
        public IActionResult UpdateEmployee([FromBody] EmployeeTransport employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _employeeService.Update(employee);

            return Ok();
        }
        [HttpGet(template: nameof(GetAllEmployees), Name = nameof(GetAllEmployees))]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<EmployeeTransport> employees = _employeeService.GetAll();
            return Ok(employees);
        }


        [HttpGet(template: "GetEmployeeById/{id}", Name = nameof(GetEmployeeById))]
        public IActionResult GetEmployeeById(long id)
        {
            EmployeeTransport employee = _employeeService.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }


       
    }
}
