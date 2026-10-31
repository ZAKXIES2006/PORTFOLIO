using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
     
        Console.WriteLine("TASK 1");

        List<string> names = new List<string>
        {
            "Zak", "Blago", "Barney", "Eli", "Judith",
            "Randeep", "Isaac", "Arne", "G-Man", "Odessa"
        };

        IOrderedEnumerable<string> orderedQuery = names.OrderBy(x => x);
        List<string> sortedNames = orderedQuery.ToList();

        Console.WriteLine("--- Sorted Names ---");
        foreach (string name in sortedNames)
        {
            Console.WriteLine(name);
        }

       
        // TASK 2: Stack<T> and Queue<T> Selection
        
        Console.WriteLine("\nTASK 2");

        List<BankAccount> sampleAccounts = new List<BankAccount>
        {
            new BankAccount("Zak", 1500.50m),
            new BankAccount("Blago", 2400.00m),
            new BankAccount("Barney", 320.10m),
            new BankAccount("Eli", 8500.25m),
            new BankAccount("Judith", 5100.75m),
            new BankAccount("Randeep", 9900.00m),
            new BankAccount("Isaac", 6400.40m),
            new BankAccount("Arne", 7100.00m),
            new BankAccount("G-Man", 0.00m),
            new BankAccount("Odessa", 150.00m)
        };

        Stack<BankAccount> accountStack = new Stack<BankAccount>(sampleAccounts);
        Queue<BankAccount> accountQueue = new Queue<BankAccount>(sampleAccounts);

        List<string> stackOwners = accountStack
            .Select(acc => acc.Owner)
            .OrderBy(owner => owner)
            .ToList();

        Console.WriteLine("Stack Owners (Alphabetical)");
        foreach (string owner in stackOwners)
        {
            Console.WriteLine(owner);
        }

        List<string> queueOwners = accountQueue
            .Select(acc => acc.Owner)
            .OrderBy(owner => owner)
            .ToList();

        Console.WriteLine("\n--- Queue Owners (Alphabetical) ---");
        foreach (string owner in queueOwners)  
        {
            Console.WriteLine(owner);
        }


        // TASK 3: Filtering and Ordering Stack & Queue
     
        Console.WriteLine("\nTASK 3");

   
        List<string> filteredStack = accountStack
            .Where(acc => acc.Owner.Contains("e", StringComparison.OrdinalIgnoreCase))
            .OrderBy(acc => acc.Balance)
            .Select(acc => $"{acc.Owner} - ${acc.Balance:N2}")
            .ToList();

        Console.WriteLine("Stack Accounts (Contains 'e', by Balance)");
        foreach (string entry in filteredStack)
        {
            Console.WriteLine(entry);
        }

      
        List<string> filteredQueue = accountQueue
            .Where(acc => acc.Owner.Contains("e", StringComparison.OrdinalIgnoreCase))
            .OrderBy(acc => acc.Balance)
            .Select(acc => $"{acc.Owner} - ${acc.Balance:N2}")
            .ToList();

        Console.WriteLine("\nQueue Accounts (Contains 'e', by Balance)");
        foreach (string entry in filteredQueue)
        {
            Console.WriteLine(entry);
        }
    }
}