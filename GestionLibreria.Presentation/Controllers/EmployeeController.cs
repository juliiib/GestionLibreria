using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibreria.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeRepository;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeRepository = employeeService;
        }

        [HttpPost]
        public ActionResult<Employee> Create([FromBody] CreateEmployeeRequest request)
        {
            try
            {
                Employee employee = _employeeRepository.AddEmployee(request);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Employee>> GetAll()
        {
            var employees = _employeeRepository.GetAllEmployees();
            if (!employees.Any())
            {
                return NotFound("No employees found.");
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(Guid id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
        }

        [HttpPatch("{id}/contact")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] UpdateEmployeeContactRequest request)
        {
            if (!_employeeRepository.UpdateEmployeeContact(id, request))
            {
                return NotFound("Employee not found.");
            }

            return NoContent();
        }

        [HttpPatch("{id}/details")]
        public ActionResult UpdateEmployeeDetails([FromRoute] Guid id, [FromBody] UpdateEmployeeDetailsRequest request)
        {
            if (!_employeeRepository.UpdateEmployeeDetails(id, request))
            {
                return NotFound("Employee not found.");
            }

            return NoContent();
        }
    }
}
