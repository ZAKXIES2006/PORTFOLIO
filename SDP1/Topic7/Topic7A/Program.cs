using System;
using System.Collections.Generic;
using System.Linq;
using ScottPlot;   
  public class BankComparer : IComparer<BankAccount>
{
    public int Compare(BankAccount x, BankAccount y)
    {
  
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        int balanceComparison = x.Balance.CompareTo(y.Balance);

        if (balanceComparison == 0)
        {
            return string.Compare(x.Owner, y.Owner, StringComparison.OrdinalIgnoreCase);
        }

        return balanceComparison;
    }
}
class Program
{
  
    static void Main(string[] args)
    {
   
        Console.WriteLine(" TASK 1\n");
        
        SortedSet<int> leaderboard = new SortedSet<int>();
        Random rnd = new Random();

        Console.WriteLine("1. Initial 10 Random Scores");
        for (int i = 0; i < 10; i++)
        {
            leaderboard.Add(rnd.Next(1, 1001)); 
        }
        DisplayScores(leaderboard);

        Console.WriteLine("\n2. Adding a New High Score (9999)");
        leaderboard.Add(9999);
        DisplayScores(leaderboard);

        Console.WriteLine("\n3. Adding a Duplicate Score (9999)");
        bool wasAdded = leaderboard.Add(9999);
        Console.WriteLine($"Did the set accept the duplicate? {wasAdded}");
        DisplayScores(leaderboard);


      
        Console.WriteLine("\n\n TASK 2\n");

       


        var sortedBankSet = new SortedSet<BankAccount>(new BankComparer());

        Console.WriteLine("1. Adding 10 Initial Accounts");
        sortedBankSet.Add(new BankAccount("Alice", 2500.50m));
        sortedBankSet.Add(new BankAccount("Bob", 150.00m));
        sortedBankSet.Add(new BankAccount("Charlie", 10000.00m));
        sortedBankSet.Add(new BankAccount("Diana", 450.75m));
        sortedBankSet.Add(new BankAccount("Ethan", 150.00m)); 
        sortedBankSet.Add(new BankAccount("Fiona", 3333.33m));
        sortedBankSet.Add(new BankAccount("George", 99.99m));
        sortedBankSet.Add(new BankAccount("Hannah", 8500.00m));
        sortedBankSet.Add(new BankAccount("Ian", 1200.00m));
        sortedBankSet.Add(new BankAccount("Julia", 560.20m));

        DisplayAccounts(sortedBankSet);

        Console.WriteLine("\n2. Adding a New High Account");
        sortedBankSet.Add(new BankAccount("Zack (High Roller)", 99999.99m));
        DisplayAccounts(sortedBankSet);

        Console.WriteLine("\n3. Adding a Duplicate Account");
        BankAccount duplicateAccount = new BankAccount("Zack (High Roller)", 99999.99m);
        bool isAccountAdded = sortedBankSet.Add(duplicateAccount);
        
        Console.WriteLine($"Was the duplicate account added? {isAccountAdded}\n");
        DisplayAccounts(sortedBankSet);
//scottplot
        CreateBarChart(sortedBankSet);
    }


    static void DisplayScores(SortedSet<int> scores)
    {
        if (scores.Count == 0)
        {
            Console.WriteLine("The leaderboard is currently empty.");
            return;
        }

        Console.WriteLine("All Scores:");
        foreach (int score in scores)
        {
            Console.WriteLine(score);
        }
        Console.WriteLine($"\nHighest Score: {scores.Max}");
        Console.WriteLine($"Lowest Score: {scores.Min}");
    }

    static void DisplayAccounts(SortedSet<BankAccount> accounts)
    {
        Console.WriteLine($"Total Accounts in Set: {accounts.Count}");
        foreach (var account in accounts)
        {
            Console.WriteLine(account.ToString());
            Console.WriteLine("-"); 
        }
    }

    static void CreateBarChart(SortedSet<BankAccount> accounts)
    {
        double[] dataY = accounts.Select(a => (double)a.Balance).ToArray();



        ScottPlot.Plot myPlot = new();
        myPlot.Add.Bars(dataY);

  
        myPlot.XLabel("Ranking");
        myPlot.YLabel("Account Balance");


        myPlot.Axes.Bottom.Label.FontSize = 20;
        myPlot.Axes.Left.Label.FontSize = 20;

        myPlot.Axes.Margins(bottom: 0, top: 0.2);

        myPlot.SavePng("Topic7A-Task3.png", 800, 600);
    }
}