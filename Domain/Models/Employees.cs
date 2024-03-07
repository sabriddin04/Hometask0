namespace Domain.Models;

public class Employees
{
    public int EmployeeID { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int DepartmentID { get; set; }

    public string? Position { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Average { get; set; }

    public decimal Amount { get; set; }

    public decimal SumOfAmount { get; set; }
}
