using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("TASK 1 - Stack (undo history)");

        Stack<string> undoHistory = new Stack<string>();
        PrintStack("Initial stack", undoHistory);

        undoHistory.Push("Typed Text");
        undoHistory.Push("Inserted Image");
        undoHistory.Push("Changed Colour");
        undoHistory.Push("Deleted Paragraph");
        PrintStack("After Push x4", undoHistory);

        Console.WriteLine($"Peek (next thing to undo): {undoHistory.Peek()}");
        PrintStack("After Peek (unchanged)", undoHistory);

        string undone = undoHistory.Pop();
        Console.WriteLine($"Pop (undid): {undone}");
        PrintStack("After Pop", undoHistory);

        Console.WriteLine();
        Console.WriteLine("TASK 2 - Queue (printer jobs)");

        Queue<string> printJobs = new Queue<string>();
        PrintQueue("Initial queue", printJobs);

        printJobs.Enqueue("Print Job 1");
        printJobs.Enqueue("Print Job 2");
        printJobs.Enqueue("Print Job 3");
        printJobs.Enqueue("Print Job 4");
        PrintQueue("After Enqueue x4", printJobs);

        Console.WriteLine($"Peek (next job to print): {printJobs.Peek()}");
        PrintQueue("After Peek (unchanged)", printJobs);

        string printed = printJobs.Dequeue();
        Console.WriteLine($"Dequeue (printed): {printed}");
        PrintQueue("After Dequeue", printJobs);

        Console.WriteLine();
        Console.WriteLine("TASK 3 - Stack<BankAccount> to Queue<BankAccount>");

        Stack<BankAccount> accountStack = new Stack<BankAccount>();
        accountStack.Push(new BankAccount("Zak", 1500.50m));
        accountStack.Push(new BankAccount("Blago", 2400.00m));
        accountStack.Push(new BankAccount("Barney", 320.10m));
        accountStack.Push(new BankAccount("Eli", 8500.25m));
        accountStack.Push(new BankAccount("Judith", 5100.75m));
        accountStack.Push(new BankAccount("Randeep", 9900.00m));
        accountStack.Push(new BankAccount("Isaac", 6400.40m));
        accountStack.Push(new BankAccount("Arne", 7100.00m));
        accountStack.Push(new BankAccount("G-Man", 0.00m));
        accountStack.Push(new BankAccount("Odessa", 150.00m));

        Console.WriteLine("Stack<BankAccount> (top to bottom):");
        PrintAccounts(accountStack);

        Queue<BankAccount> accountQueue = StackToQueue(accountStack);

        Console.WriteLine("Queue<BankAccount> (front to back):");
        PrintAccounts(accountQueue);
    }

    static Queue<BankAccount> StackToQueue(Stack<BankAccount> stack)
    {
        Queue<BankAccount> queue = new Queue<BankAccount>();
        foreach (BankAccount account in stack)
        {
            queue.Enqueue(account);
        }
        return queue;
    }

    static void PrintStack(string label, Stack<string> stack)
    {
        Console.WriteLine($"{label}: [{string.Join(", ", stack)}]  (count {stack.Count})");
    }

    static void PrintQueue(string label, Queue<string> queue)
    {
        Console.WriteLine($"{label}: [{string.Join(", ", queue)}]  (count {queue.Count})");
    }

    static void PrintAccounts(IEnumerable<BankAccount> accounts)
    {
        int position = 1;
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine($"  {position}. {account.Owner} - ${account.Balance:N2}");
            position++;
        }
    }
}
