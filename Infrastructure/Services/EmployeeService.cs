using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DapperContext context;

    public EmployeeService()
    {
        context=new DapperContext();
    }


    public List<Employees> GetEmployees()
    {
        var sql=" select * from Employees";

        return context.Connection().Query<Employees>(sql).ToList();
    }



     public void DeleteEmployee(int id)
    {
        var sql = "delete from Employees where EmployeeID=@id ";

        context.Connection().Execute(sql, new { Id = id });

    }

    public void UpdateDepartment(Employees employee)
    {
        var sql = "Update Employees set FirstName=@FirstName,LastName=@LastName,DepartmentID=@DepartmentID,Position=@Position,HireDate=@HireDate where EmployeeID=@id";

        context.Connection().Execute(sql, employee);

    }

     public void AddEmployee(Employees employee)
    {
        var sql = @"insert into Employees( FirstName,LastName,DepartmentID,Position,HireDate)
                       values(@FirstName,@LastName,@DepartmentID,@Position,@HireDate)";
        context.Connection().Execute(sql,employee);

    }
    
    

    


}
