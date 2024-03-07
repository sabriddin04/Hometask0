namespace WebApi.Controllers;

using Infrastructure.Services;

using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Npgsql.Replication.PgOutput.Messages;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
       private readonly EmployeeService employeeService;

    public EmployeeController  ()
    {
        employeeService= new EmployeeService();
    }


    [HttpGet("get-Employees")]

    public List<Employees> GetEmployees()
    {
        return employeeService.GetEmployees();
    }

    [HttpPost("create-employees/{employee}")]

    public void AddDepartment([FromForm] Employees employee)
    {
        employeeService.AddEmployee(employee);
    }

    [HttpDelete("delete-Employees/{id}")]

    public void DeleteDepartment([FromBody] int id)
    {
        employeeService.DeleteEmployee(id);
    }

    [HttpPut("update-Employees/{employee}")]

    public void UpdateDepartment([FromForm] Employees employee)
    {

        employeeService.UpdateDepartment(employee);

    }
   
 


}
