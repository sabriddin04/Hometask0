namespace WebApi.Controllers;

using Infrastructure.Services;

using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Npgsql.Replication.PgOutput.Messages;


[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService departmentService;

    public DepartmentController()
    {
        departmentService = new DepartmentService();
    }


    [HttpGet("get-Departments")]

    public List<Departments> GetDepartments()
    {
        return departmentService.GetDepartments();
    }

    [HttpPost("create-departments/{department}")]

    public void AddDepartment([FromForm] Departments department)
    {
        departmentService.AddDepartment(department);
    }

    [HttpDelete("delete-departments/{id}")]

    public void DeleteDepartment([FromBody] int id)
    {
        departmentService.DeleteDepartment(id);
    }

    [HttpPut("update-departments/{department}")]

    public void UpdateDepartment([FromForm] Departments department)
    {

        departmentService.UpdateDepartment(department);

    }
   
    [HttpGet("get-departmnet-with-employees/{id}")]

     public DepartmentEmployees GetDepartmentWithEmployees(int id)
    {
     
      return departmentService.GetDepartmentWithEmployees(id);

    }

    [HttpGet("get-departmnet-with-employees-with-avg/{id}")]
    
      public DepartmentEmployees GetDepartmentWithEmployeesWithAverage(int id)
    {
       return departmentService.GetDepartmentWithEmployeesWithAverage(id);
    }

    [HttpGet("get-employees-with-salary-in-past month")]

      public List<Employees> GetEmployeesWithSalaryInPastMonth()
    {
       return departmentService.GetEmployeesWithSalaryInPastMonth();
    }

     [HttpGet("Get-Employees-With-SumOfAmount-HavingMore")]

        public List<Employees> GetEmployeesWithSumOfAmountHavingMore()
        {
          return   departmentService.GetEmployeesWithSumOfAmountHavingMore();
        }
      
    
    


}
