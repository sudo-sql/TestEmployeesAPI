using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestEmployeesAPI.Models;

namespace TestEmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public static List<Employee> employees = new() //This is only a list of employees but acts as a placeholder where a database conneciton would ideally exist.
        {
            new Employee { Id=1, FirstName="Brandy", LastName="Calhoun", Dept="IT", YearsOfService= 20},
            new Employee { Id=1, FirstName="Will", LastName="Hendrick", Dept="IT", YearsOfService= 15},
            new Employee { Id=2, FirstName="Paul", LastName="Swanson", Dept="IT", YearsOfService= 10},
            new Employee { Id=3, FirstName="Trevor", LastName="Cassell", Dept="IT", YearsOfService= 5} 
        };

        [HttpGet] //This will retrieve all employees.
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")] //This allows retrieving an employee by an ID.
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPost] //Thiss will create a new employee.
        public IActionResult CreateEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }

        [HttpPut] //This will update records of an employee.
        public IActionResult UpdateEmployee(Employee employee)
        {
            var employeeInList = employees.Find(x => x.Id == employee.Id);
            if (employee == null)
            {
                return NotFound("Invalid employee information");
            }
            employeeInList.FirstName = employee.FirstName;
            employeeInList.LastName = employee.LastName;
            employeeInList.Dept = employee.Dept;
            employeeInList.YearsOfService = employee.YearsOfService;
            return Ok(employeeInList);
        }

        [HttpDelete] //This will delete an employee.
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Invalid employee information");
            }
            employees.Remove(employee);
            return Ok(employee);
        }

    }
}