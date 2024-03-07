namespace Domain.Models;

public class Salaries
{
    public int SalaryID { get; set; }

    public int EmployeeID { get; set; }

    public decimal Amount { get; set; }

    public DateTime Data { get; set; }
}
