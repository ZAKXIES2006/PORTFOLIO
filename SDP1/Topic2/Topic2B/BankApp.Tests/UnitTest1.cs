using BankApp;

namespace BankApp.Tests;

public class BankAccountTests
{
    [Fact]
    public void Constructor_SetsOwnerAndBalance()
    {
        var acc = new BankAccount("Zak", 100m);
        Assert.Equal("Zak", acc.Owner);
        Assert.Equal(100m, acc.Balance);
    }

    [Fact]
    public void Constructor_DefaultBalanceIsZero()
    {
        var acc = new BankAccount("Zak");
        Assert.Equal(0m, acc.Balance);
    }

    [Fact]
    public void Owner_CanBeChanged()
    {
        var acc = new BankAccount("Zak");
        acc.Owner = "Sam";
        Assert.Equal("Sam", acc.Owner);
    }

    [Fact]
    public void Deposit_Decimal_IncreasesBalance()
    {
        var acc = new BankAccount("Zak", 100m);
        acc.Deposit(50m);
        Assert.Equal(150m, acc.Balance);
    }

    [Fact]
    public void Deposit_Int_IncreasesBalance()
    {
        var acc = new BankAccount("Zak", 100m);
        acc.Deposit(10);
        Assert.Equal(110m, acc.Balance);
    }

    [Fact]
    public void Deposit_Double_IncreasesBalance()
    {
        var acc = new BankAccount("Zak", 100m);
        acc.Deposit(5.5);
        Assert.Equal(105.5m, acc.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Deposit_NonPositive_Throws(decimal amount)
    {
        var acc = new BankAccount("Zak", 100m);
        Assert.Throws<ArgumentException>(() => acc.Deposit(amount));
    }

    [Fact]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var acc = new BankAccount("Zak", 100m);
        acc.Withdraw(30m);
        Assert.Equal(70m, acc.Balance);
    }

    [Fact]
    public void Withdraw_ExactBalance_LeavesZero()
    {
        var acc = new BankAccount("Zak", 100m);
        acc.Withdraw(100m);
        Assert.Equal(0m, acc.Balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Withdraw_NonPositive_Throws(decimal amount)
    {
        var acc = new BankAccount("Zak", 100m);
        Assert.Throws<ArgumentException>(() => acc.Withdraw(amount));
    }

    [Fact]
    public void Withdraw_MoreThanBalance_Throws()
    {
        var acc = new BankAccount("Zak", 100m);
        Assert.Throws<InvalidOperationException>(() => acc.Withdraw(1000m));
        Assert.Equal(100m, acc.Balance);
    }
}