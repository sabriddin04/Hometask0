using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class DepartmentService
{

    private readonly DapperContext context;

    public DepartmentService()
    {
        context = new DapperContext();
    }

    public void AddDepartment(Departments department)
    {
        var sql = "insert into Departments (DepartmentName) values(@DepartmentName)";

        context.Connection().Execute(sql, department);

    }

    public List<Departments> GetDepartments()
    {
        var sql = "select * from Departments order by DepartmentID";

        return context.Connection().Query<Departments>(sql).ToList();

    }

    public void DeleteDepartment(int id)
    {
        var sql = "delete from Depatments where DepartmentID=@id ";

        context.Connection().Execute(sql, new { Id = id });

    }

    public void UpdateDepartment(Departments department)
    {
        var sql = "Update Departments set DepartmentName=@DepartmentName where DepartmentID=@DepartmentID ";

        context.Connection().Execute(sql, department);

    }

    public DepartmentEmployees GetDepartmentWithEmployees(int id)
    {
        var sql1 = @"select * from Departments where DepartmentID=@id;
       
                     select * from Employees where DepartmentID=@id;";

        using (var multiple = context.Connection().QueryMultiple(sql1, new { Id = id }))
        {
            var sabr = new DepartmentEmployees();
            sabr.Department = multiple.ReadFirst<Departments>();
            sabr.Employees = multiple.Read<Employees>().ToList();

            return sabr;
        }
    }

    public DepartmentEmployees GetDepartmentWithEmployeesWithAverage(int id)
    {
        var sql1 = @"select * from Departments where DepartmentID=@id;
       
                     select  Employees.FirstName,Employees.LastName,Employees.DepartmentID,Employees.Position,Employees.HireDate,Employees.EmployeeID,Avg(Amount) as Average from Employees
                      join Salaries on Employees.EmployeeID=Salaries.EmployeeID 
                      where Employees.DepartmentID=@id 
                      group by FirstName,Employees.LastName,Employees.DepartmentID,Employees.Position,Employees.HireDate,Employees.EmployeeID; ";

        using (var multiple = context.Connection().QueryMultiple(sql1, new { Id = id }))
        {
            var sabr = new DepartmentEmployees();
            sabr.Department = multiple.ReadFirst<Departments>();
            sabr.Employees = multiple.Read<Employees>().ToList();

            return sabr;
        }
    }

  
      public List<Employees> GetEmployeesWithSumOfAmountHavingMore()
      
    {
        var sql1="select Avg(Amount) from Salaries";

        var everage= context.Connection().ExecuteScalar<int>(sql1);

        var sql2=@"select  Employees.FirstName,Sum(Amount)
                   from Employees
                   join Salaries on Employees.EmployeeID=Salaries.EmployeeID
                   group by FirstName
                   having Sum(Amount) > @everage";

        return context.Connection().Query<Employees>(sql2,new{Everage=everage}).ToList();
    
    }


     public List<Employees> GetEmployeesWithSalaryInPastMonth()
    {
        var sql = @"select  Employees.FirstName,Employees.LastName,Employees.DepartmentID,Employees.Position,Employees.HireDate,Employees.EmployeeID,Salaries.Amount
                   from Employees 
                   join Salaries on Employees.EmployeeID=Salaries.EmployeeID
                   where Salaries.Data>'2024-02-01'  or Salaries.Data='2024-02-01' ;";

             return   context.Connection().Query<Employees>(sql).ToList();

    }




}
