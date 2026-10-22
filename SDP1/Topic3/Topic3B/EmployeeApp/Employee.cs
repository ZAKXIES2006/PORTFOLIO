namespace EmployeeApp;

public abstract class Employee
{
    public const decimal TaxRate = 0.2m;

    public string Name { get; set; }

    protected Employee(string name)
    {
        Name = name;
    }

    public abstract decimal CalculatePay();
}
