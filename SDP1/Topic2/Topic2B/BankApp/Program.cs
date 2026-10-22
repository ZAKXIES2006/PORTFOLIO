using BankApp;

var account = new BankAccount("Zak", 100m);
Console.WriteLine($"{account.Owner} starts with {account.Balance:C}");

account.Deposit(50m);
Console.WriteLine($"After depositing $50: {account.Balance:C}");

account.Withdraw(30m);
Console.WriteLine($"After withdrawing $30: {account.Balance:C}");

try
{
    account.Withdraw(1000m);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Withdraw $1000 failed: {ex.Message}");
}
