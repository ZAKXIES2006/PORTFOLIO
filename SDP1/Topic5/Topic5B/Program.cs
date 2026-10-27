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
    }
}