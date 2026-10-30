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

        // Dequeue: print (remove) the job at the front
        string printed = printJobs.Dequeue();
        Console.WriteLine($"Dequeue (printed): {printed}");
        PrintQueue("After Dequeue", printJobs);
    }

    static void PrintStack(string label, Stack<string> stack)
    {
        Console.WriteLine($"{label}: [{string.Join(", ", stack)}]  (count {stack.Count})");
    }

    static void PrintQueue(string label, Queue<string> queue)
    {
        Console.WriteLine($"{label}: [{string.Join(", ", queue)}]  (count {queue.Count})");
    }
}
