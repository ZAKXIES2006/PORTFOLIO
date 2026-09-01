using System;

class Program
{
    static void Main()
    {

        string[] names =
        {
            "zak",
            "hamdan",
            "William",
            "Amelia",
            "Benjamin",
            "Sophia",
            "Alexander",
            "Isabella",
            "Christopher",
            "Elizabeth"
        };

        Console.WriteLine("Original Array:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        string longest = names[0];
        string shortest = names[0];

        foreach (string name in names)
        {
            if (name.Length > longest.Length)
            {
                longest = name;
            }

            if (name.Length < shortest.Length)
            {
                shortest = name;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Longest name: " + longest);
        Console.WriteLine("Shortest name: " + shortest);

        Console.WriteLine();
        Console.WriteLine("Array before sorting:");
        foreach (string name in names)
        {
            Console.Write(name + " ");
        }

        // Sort the array
        Array.Sort(names);

        // Print array after sorting
        Console.WriteLine();
        Console.WriteLine("Array after sorting:");
        foreach (string name in names)
        {
            Console.Write(name + " ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Array before reversing:");
        foreach (string name in names)
        {
            Console.Write(name + " ");
        }

        Array.Reverse(names);

        Console.WriteLine();
        Console.WriteLine("Array after reversing:");
        foreach (string name in names)
        {
            Console.Write(name + " ");
        }

        Console.WriteLine();
    }
}