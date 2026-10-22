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
Console.WriteLine("\n Overloading examples ");

account.Deposit(10);
Console.WriteLine($"Deposit(10)int: {account.Balance:C}");

account.Deposit(5.5);
Console.WriteLine($"Deposit(5.5)  double {account.Balance:C}");

account.Deposit(2.25m);
Console.WriteLine($"Deposit(2.25m) decimal:{account.Balance:C}");

byte small = 3;
account.Deposit(small);
Console.WriteLine($"Deposit(byte)  int:   {account.Balance:C}");

float f = 1.5f;
account.Deposit(f);
Console.WriteLine($"Deposit(float) double: {account.Balance:C}");
