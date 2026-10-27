using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numbers = new LinkedList<int>();

        numbers.AddFirst(30);
        numbers.AddFirst(20);
        numbers.AddFirst(10);
        numbers.AddLast(40);
        numbers.AddLast(50);

        LinkedListNode<int> node30 = numbers.Find(30)!;
        LinkedListNode<int> node50 = numbers.Find(50)!;

        numbers.AddBefore(node30, 25);
        numbers.AddAfter(node30, 35);
        numbers.AddAfter(node50, 60);
        numbers.AddAfter(numbers.Last!, 70);
        numbers.AddAfter(numbers.Last!, 80);
        numbers.AddAfter(numbers.Last!, 90);
        numbers.AddAfter(numbers.Last!, 100);

        numbers.RemoveFirst();
        numbers.RemoveLast();
        numbers.Remove(35);

        LinkedListNode<int>? current = numbers.First;
        for (int i = 1; i < 5 && current != null; i++)
        {
            current = current.Next;
        }

        if (current != null)
        {
            numbers.Remove(current);
        }

        Console.WriteLine("Remaining elements in LinkedList:");
        foreach (int num in numbers)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
        Console.WriteLine();

        
        Person fred = new Person("Fred", "Smith", 21);
        Person sarah = new Person("Sarah", "Nguyen", 34);
        Person tom = new Person("Tom", "Brown", 8);
        Person aisha = new Person("Aisha", "Khan", 19);
        Person liam = new Person("Liam", "Walker", 52);
        Person mia = new Person("Mia", "Rossi", 15);
        Person jack = new Person("Jack", "Taylor", 27);
        Person zoe = new Person("Zoe", "Chen", 3);
        Person omar = new Person("Omar", "Haddad", 41);
        Person ella = new Person("Ella", "Martin", 67);

        List<Person> peopleList = new List<Person> { fred, sarah, tom, aisha, liam, mia, jack, zoe, omar, ella };

        LinkedList<Person> people = ToLinkedList(peopleList);
        Console.WriteLine("People before sorting:");
        Console.WriteLine(PrintPeople(people));

        SortPeople(people);
        Console.WriteLine("People after sorting by age:");
        Console.WriteLine(PrintPeople(people));

        // quick tests
        Console.WriteLine("Tests:");
        Console.WriteLine($"Same count as the List: {(people.Count == peopleList.Count ? "PASS" : "FAIL")}");
        Console.WriteLine($"Sorted youngest to oldest: {(IsSortedByAge(people) ? "PASS" : "FAIL")}");
        Console.WriteLine($"Youngest is Zoe: {(people.First!.Value == zoe ? "PASS" : "FAIL")}");
        Console.WriteLine($"Oldest is Ella: {(people.Last!.Value == ella ? "PASS" : "FAIL")}");

        var empty = SortPeople(new LinkedList<Person>());
        Console.WriteLine($"Sorting an empty list works: {(empty.Count == 0 ? "PASS" : "FAIL")}");
        Console.WriteLine();

        fred.Age = 22;
        Console.WriteLine("Changed fred's age to 22 after ToLinkedList:");
        Console.WriteLine($"Fred in the List: {peopleList[0].Age}");
        Console.WriteLine($"Fred in the LinkedList: {people.Find(fred)!.Value.Age}");
    }

    public static LinkedList<Person> ToLinkedList(List<Person> people)
    {
        var linkedList = new LinkedList<Person>();
        foreach (Person person in people)
        {
            linkedList.AddLast(person);
        }
        return linkedList;
    }

    public static string PrintPeople(LinkedList<Person> people)
    {
        string result = "";
        foreach (Person person in people)
        {
            result += $"{person.FullName} - {person.Age}\n";
        }
        return result;
    }

    public static LinkedList<Person> SortPeople(LinkedList<Person> people)
    {
        var sorted = new LinkedList<Person>();

        foreach (Person person in people)
        {
            LinkedListNode<Person>? node = sorted.First;
            while (node != null && node.Value.Age <= person.Age)
            {
                node = node.Next;
            }

            if (node == null)
            {
                sorted.AddLast(person);
            }
            else
            {
                sorted.AddBefore(node, person);
            }
        }

        // put the sorted order back into the original list and return it
        people.Clear();
        foreach (Person person in sorted)
        {
            people.AddLast(person);
        }
        return people;
    }

    // checks every person is the same age or younger than the next one
    static bool IsSortedByAge(LinkedList<Person> people)
    {
        LinkedListNode<Person>? node = people.First;
        while (node?.Next != null)
        {
            if (node.Value.Age > node.Next.Value.Age)
            {
                return false;
            }
            node = node.Next;
        }
        return true;
    }
}
