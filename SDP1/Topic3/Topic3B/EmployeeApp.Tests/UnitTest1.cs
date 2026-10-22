using EmployeeApp;

namespace EmployeeApp.Tests;

public class EmployeeTests
{
    [Fact]
    public void TaxRate_IsPointTwo()
    {
        Assert.Equal(0.2m, Employee.TaxRate);
    }

    [Fact]
    public void Name_CanBeSetAndChanged()
    {
        var emp = new FullTimeEmployee("Bill", 1000m);
        Assert.Equal("Bill", emp.Name);
        emp.Name = "William";
        Assert.Equal("William", emp.Name);
    }
}

public class FullTimeEmployeeTests
{
    [Fact]
    public void Constructor_SetsSalary()
    {
        var emp = new FullTimeEmployee("Bill", 60000m);
        Assert.Equal(60000m, emp.AnnualSalary);
    }

    [Fact]
    public void AnnualSalary_CanBeChanged()
    {
        var emp = new FullTimeEmployee("Bill", 60000m);
        emp.AnnualSalary = 70000m;
        Assert.Equal(70000m, emp.AnnualSalary);
    }

    [Fact]
    public void CalculatePay_ReturnsSalaryMinusTax()
    {
        var emp = new FullTimeEmployee("Bill", 60000m);
        Assert.Equal(48000m, emp.CalculatePay());
    }

    [Fact]
    public void CalculatePay_ZeroSalary_ReturnsZero()
    {
        var emp = new FullTimeEmployee("Bill", 0m);
        Assert.Equal(0m, emp.CalculatePay());
    }

    [Fact]
    public void GenerateReport_IncludesNameAndType()
    {
        var emp = new FullTimeEmployee("Bill", 60000m);
        string report = emp.GenerateReport();
        Assert.Contains("Bill", report);
        Assert.Contains("Full-time", report);
    }
}

public class ContractorTests
{
    [Fact]
    public void Constructor_SetsRateAndHours()
    {
        var c = new Contractor("Fred", 50m, 40m);
        Assert.Equal(50m, c.Rate);
        Assert.Equal(40m, c.Hours);
    }

    [Fact]
    public void RateAndHours_CanBeChanged()
    {
        var c = new Contractor("Fred", 50m, 40m);
        c.Rate = 60m;
        c.Hours = 10m;
        Assert.Equal(60m, c.Rate);
        Assert.Equal(10m, c.Hours);
    }

    [Fact]
    public void CalculatePay_ReturnsRateTimesHoursMinusTax()
    {
        var c = new Contractor("Fred", 50m, 40m);
        Assert.Equal(1600m, c.CalculatePay());
    }

    [Fact]
    public void CalculatePay_ZeroHours_ReturnsZero()
    {
        var c = new Contractor("Fred", 50m, 0m);
        Assert.Equal(0m, c.CalculatePay());
    }

    [Fact]
    public void GenerateReport_IncludesNameAndType()
    {
        var c = new Contractor("Fred", 50m, 40m);
        string report = c.GenerateReport();
        Assert.Contains("Fred", report);
        Assert.Contains("Contractor", report);
    }
}

public class PolymorphismTests
{
    [Fact]
    public void ListOfEmployees_UsesEachTypesOwnCalculatePay()
    {
        List<Employee> staff = new()
        {
            new FullTimeEmployee("Bill", 60000m),
            new Contractor("Fred", 50m, 40m)
        };

        Assert.Equal(48000m, staff[0].CalculatePay());
        Assert.Equal(1600m, staff[1].CalculatePay());
    }

    [Fact]
    public void BothClasses_AreReportable()
    {
        Employee a = new FullTimeEmployee("Bill", 60000m);
        Employee b = new Contractor("Fred", 50m, 40m);
        Assert.IsAssignableFrom<IReportable>(a);
        Assert.IsAssignableFrom<IReportable>(b);
    }
}
