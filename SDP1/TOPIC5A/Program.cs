using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("TASK 1: ARRAYS");

        string[] names = { "Alexander", "Mia", "Benjamin", "Charlotte", "Eli", "Christopher", "Sophia", "Dan", "Elizabeth", "Ava" };

        
        Console.WriteLine(" 1. All Names in Array ");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        string shortest = names[0];
        string longest = names[0];

        foreach (string name in names)
        {
            if (name.Length < shortest.Length)
            {
                shortest = name;
            }
            if (name.Length > longest.Length)
            {
                longest = name;
            }
        }

        Console.WriteLine("\n--- 2. Longest and Shortest Names ---");
        Console.WriteLine($"Shortest Name: {shortest} ({shortest.Length} chars)");
        Console.WriteLine($"Longest Name:  {longest} ({longest.Length} chars)");

  
        Console.WriteLine("\n--- 3. Sorting Array ---");
        Console.WriteLine("Before Sorting: " + string.Join(", ", names));
        Array.Sort(names);
        Console.WriteLine("After Sorting:  " + string.Join(", ", names));

        Console.WriteLine("\n--- 4. Reversing Array ---");
        Console.WriteLine("Before Reversing: " + string.Join(", ", names));
        Array.Reverse(names);
        Console.WriteLine("After Reversing:  " + string.Join(", ", names));


        Console.WriteLine("\nTASK 2: LISTS ");

        
        List<string> students = new List<string>();

        students.Add("Alice");
        students.Add("Bob");
        students.Add("Charlie");

        students.Insert(1, "David"); 

        string[] initialBatch = { "Daniel", "Emma", "Danielle", "Frank", "Grace" };
        students.AddRange(initialBatch); 

        students.Remove("Bob"); 

        students.Add("Hannah");
        students.Add("Ian");
        students.Add("Jack");

        Console.WriteLine("--- 1. List Methods (Add, Insert, AddRange, Remove) ---");
        Console.WriteLine($"Total Students ({students.Count}): " + string.Join(", ", students));

       
        string searchExact = "Emma";
        int exactIndex = students.IndexOf(searchExact);

        Console.WriteLine("\n--- 2. Exact Search ---");
        if (exactIndex != -1)
        {
            Console.WriteLine($"Found '{searchExact}' at index: {exactIndex}");
        }
        else
        {
            Console.WriteLine($"'{searchExact}' was not found.");
        }

        // 3. Partial Search using string.Contains()
        string partialTerm = "Dan";
        List<string> matches = new List<string>();

        foreach (string student in students)
        {
            if (student.Contains(partialTerm, StringComparison.OrdinalIgnoreCase))
            {
                matches.Add(student);
            }
        }

        Console.WriteLine("\n--- 3. Partial Search ---");
        Console.WriteLine($"Names containing '{partialTerm}': " + string.Join(", ", matches));

       
        int totalCharacters = 0;
        foreach (string student in students)
        {
            totalCharacters += student.Length;
        }

        Console.WriteLine("\n4. Sum of Name Lengths ");
        Console.WriteLine($"Total character count of all names: {totalCharacters}");

        List<string> task1List = new List<string>(names); 

        Console.WriteLine("\n5. Converting Array to List & Combining ");
        Console.WriteLine("Converted Task 1 List: " + string.Join(", ", task1List));

        students.AddRange(task1List); 

        Console.WriteLine($"Final Combined List ({students.Count} items):");
        Console.WriteLine(string.Join(", ", students));
    }
}