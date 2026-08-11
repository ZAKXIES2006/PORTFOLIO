namespace PayrollApp.Tests;

using System;
using Xunit;

public class PayrollTests
{
    [Fact]
    public void Constructor_ValidInput_SetsProperties()
    {
        var p = new Payroll(40, 25m, 0.15m);
        Assert.Equal(40, p.Hours);
        Assert.Equal(25m, p.Rate);
        Assert.Equal(0.15m, p.TaxRate);
    }

    [Fact]
    public void Constructor_NegativeHours_Throws() =>
        Assert.Throws<ArgumentException>(() => new Payroll(-1, 25m, 0.15m));

    [Fact]
    public void Constructor_NegativeRate_Throws() =>
        Assert.Throws<ArgumentException>(() => new Payroll(40, -1m, 0.15m));

    [Fact]
    public void Constructor_NegativeTaxRate_Throws() =>
        Assert.Throws<ArgumentException>(() => new Payroll(40, 25m, -0.1m));

    [Fact]
    public void Constructor_TaxRateAboveOne_Throws() =>
        Assert.Throws<ArgumentException>(() => new Payroll(40, 25m, 1.5m));

    [Fact]
    public void CalculateNetPay_ReturnsGrossMinusTax()
    {
        var p = new Payroll(40, 25m, 0.20m);
        Assert.Equal(800m, p.CalculateNetPay());
    }

    [Fact]
    public void ChangeTaxRate_ValidValue_Updates()
    {
        var p = new Payroll(40, 25m, 0.15m);
        p.ChangeTaxRate(0.25m);
        Assert.Equal(0.25m, p.TaxRate);
    }

    [Fact]
    public void ChangeTaxRate_Invalid_Throws()
    {
        var p = new Payroll(40, 25m, 0.15m);
        Assert.Throws<ArgumentException>(() => p.ChangeTaxRate(-0.1m));
    }

    [Fact]
    public void HoursSetter_Negative_Throws()
    {
        var p = new Payroll(40, 25m, 0.15m);
        Assert.Throws<ArgumentException>(() => p.Hours = -1);
    }

    [Fact]
    public void RateSetter_Negative_Throws()
    {
        var p = new Payroll(40, 25m, 0.15m);
        Assert.Throws<ArgumentException>(() => p.Rate = -1m);
    }
}