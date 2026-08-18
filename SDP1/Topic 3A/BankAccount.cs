using System;

class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }

        Balance -= amount;
    }

    // Virtual method
    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine("Account: BankAccount");
        Console.WriteLine("Owner: " + Owner);
        Console.WriteLine("Balance: $" + Balance);
    }
}


// SavingsAccount inherits from BankAccount
class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(string owner, decimal balance, decimal interestRate)
        : base(owner, balance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Balance += interest;
    }

    // Override the virtual method
    public override void DisplayAccountInfo()
    {
        Console.WriteLine("Account: SavingsAccount");
        Console.WriteLine("Owner: " + Owner);
        Console.WriteLine("Balance: $" + Balance);
        Console.WriteLine("Interest rate: " + InterestRate + "%");
    }
}


// CheckingAccount inherits from BankAccount
class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string owner, decimal balance, decimal transactionFee)
        : base(owner, balance)
    {
        TransactionFee = transactionFee;
    }

    public override void Withdraw(decimal amount)
    {
        decimal totalCost = amount + TransactionFee;

        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (totalCost > Balance)
        {
            throw new InvalidOperationException(
                "Insufficient balance including transaction fee."
            );
        }

        Balance -= totalCost;
    }

    // Override the virtual method
    public override void DisplayAccountInfo()
    {
        Console.WriteLine("Account: CheckingAccount");
        Console.WriteLine("Owner: " + Owner);
        Console.WriteLine("Balance: $" + Balance);
        Console.WriteLine("Transaction fee: $" + TransactionFee);
    }
}


class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount(
            "Jordan",
            1500m,
            3.5m
        );

        CheckingAccount checking = new CheckingAccount(
            "Alex",
            2000m,
            2m
        );

        // Display information for both accounts
        savings.DisplayAccountInfo();

        Console.WriteLine();

        checking.DisplayAccountInfo();
    }
}