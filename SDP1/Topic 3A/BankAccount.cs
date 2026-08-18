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
}


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
}


class CheckingAccount : BankAccount
{
    public decimal TransactionFee { get; set; }

    public CheckingAccount(string owner, decimal balance, decimal transactionFee)
        : base(owner, balance)
    {
        TransactionFee = transactionFee;
    }

    // Override Withdraw to include transaction fee
    public override void Withdraw(decimal amount)
    {
        decimal totalCost = amount + TransactionFee;

        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        if (totalCost > Balance)
        {
            throw new InvalidOperationException("Insufficient balance including transaction fee.");
        }

        Balance -= totalCost;
    }
}


class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount(
            "Zak",
            1000m,
            5m
        );

        Console.WriteLine("=== Savings Account ===");
        Console.WriteLine("Owner: " + savings.Owner);
        Console.WriteLine("Starting balance: $" + savings.Balance);
        Console.WriteLine("Interest rate: " + savings.InterestRate + "%");

        savings.ApplyInterest();

        Console.WriteLine("Balance after interest: $" + savings.Balance);


        
        CheckingAccount checking = new CheckingAccount(
            "Ahmed",
            1000m,
            2m
        );

        Console.WriteLine();
        Console.WriteLine("=== Checking Account ===");
        Console.WriteLine("Owner: " + checking.Owner);
        Console.WriteLine("Starting balance: $" + checking.Balance);
        Console.WriteLine("Transaction fee: $" + checking.TransactionFee);

        checking.Withdraw(100m);

        Console.WriteLine("Balance after $100 withdrawal + fee: $" + checking.Balance);
    }
}