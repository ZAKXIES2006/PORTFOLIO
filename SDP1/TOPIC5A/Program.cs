using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        List<string> students = new List<string>();


        students.Add("Alice");
        students.Add("Bob");
        students.Add("Charlie");

        students.Insert(1, "David");

 
        string[] newBatch = { "Daniel", "Emma", "Danielle", "Frank", "Grace" };
        students.AddRange(newBatch);

     
        students.Remove("Bob");

        students.Add("Hannah");
        students.Add("Ian");
        students.Add("Jack");

        Console.WriteLine("Current Student List (Count: " + students.Count + ")");
        Console.WriteLine(string.Join(", ", students));

        string searchExact = "Emma";
        int exactIndex = students.IndexOf(searchExact);

        Console.WriteLine("\n Exact Search ");
        if (exactIndex != -1)
        {
            Console.WriteLine($"Found '{searchExact}' at index: {exactIndex}");
        }
        else
        {
            Console.WriteLine($"'{searchExact}' was not found in the list.");
        }

        string partialTerm = "Dan";
        List<string> matches = new List<string>();

        foreach (string name in students)
        {
            if (name.Contains(partialTerm, StringComparison.OrdinalIgnoreCase))
            {
                matches.Add(name);
            }
        }

        Console.WriteLine("\nPartial Search ");
        Console.WriteLine($"Names containing '{partialTerm}': " + string.Join(", ", matches));

        int totalCharacters = 0;
        foreach (string name in students)
        {
            totalCharacters += name.Length;
        }

        Console.WriteLine("\nTotal Name Lengths");
        Console.WriteLine($"Sum of all name lengths: {totalCharacters} characters");

        string[] task1Array = { "Alexander", "Mia", "Benjamin", "Charlotte", "Eli" };


        List<string> task1List = new List<string>(task1Array);

        Console.WriteLine("\nMerging Task 1 Array into List");
        Console.WriteLine("Task 1 converted List: " + string.Join(", ", task1List));

    
        students.AddRange(task1List);

        Console.WriteLine("Final Combined List (Count: " + students.Count + "):");
        Console.WriteLine(string.Join(", ", students));
    }
}