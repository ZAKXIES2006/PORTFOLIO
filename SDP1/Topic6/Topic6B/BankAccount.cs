public class BankAccount
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }
}