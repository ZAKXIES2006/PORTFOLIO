namespace EmployeeApp;

public class Contractor : Employee, IReportable
{
    public decimal Rate { get; set; }
    public decimal Hours { get; set; }

    public Contractor(string name, decimal rate, decimal hours) : base(name)
    {
        Rate = rate;
        Hours = hours;
    }

    public override decimal CalculatePay()
    {
        decimal gross = Rate * Hours;
        decimal tax = gross * TaxRate;
        return gross - tax;
    }

    public string GenerateReport()
    {
        decimal gross = Rate * Hours;
        return $"{Name} (Contractor): {Hours} hrs @ {Rate:C}/hr = {gross:C}, " +
               $"Tax {gross * TaxRate:C}, Net pay {CalculatePay():C}";
    }
}
