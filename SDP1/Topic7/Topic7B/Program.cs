using System;
using System.Collections.Generic;
using System.Linq;
public class ScoreComparer : IComparer<ScoreEntry>
{
    public int Compare(ScoreEntry? x, ScoreEntry? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        int scoreComp = x.Score.CompareTo(y.Score);
        if (scoreComp != 0) return scoreComp;

        int stageComp = x.StageReached.CompareTo(y.StageReached);
        if (stageComp != 0) return stageComp;

        return x.AchievedAt.CompareTo(y.AchievedAt);
    }
}
class Program
{
    static void Main()
    {
        var sortedScores = new SortedDictionary<int, string>();




        // 1. Add 10 players with different scores
        sortedScores.Add(120, "Alice");
        sortedScores.Add(450, "Bob");
        sortedScores.Add(230, "Charlie");
        sortedScores.Add(890, "David");
        sortedScores.Add(310, "Emma");
        sortedScores.Add(670, "Frank");
        sortedScores.Add(150, "Grace");
        sortedScores.Add(990, "Hannah");
        sortedScores.Add(540, "Ian");
        sortedScores.Add(780, "Jack");

        // 2. this prints the top 3 scores
        Console.WriteLine("Top 3 Scores ");
        foreach (var entry in sortedScores.Reverse().Take(3))
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        // 3. this 3ill print the bottom 3 scores
        Console.WriteLine("\n Bottom 3 Scores ");
        foreach (var entry in sortedScores.Take(3))
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        int playerKeyToRemove = sortedScores.FirstOrDefault(x => x.Value == "Charlie").Key;
        if (playerKeyToRemove != 0 || sortedScores.ContainsKey(playerKeyToRemove))
        {
            sortedScores.Remove(playerKeyToRemove);
        }

        Console.WriteLine("\n--- Remaining Players ---");
        foreach (var entry in sortedScores)
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        // 5. Attempt duplicate score (same key, different name) -> throws ArgumentException
        try
        {
            Console.WriteLine("\nAttempting duplicate score (450, 'Zack')...");
            sortedScores.Add(450, "Zack");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nAttempting duplicate name (820, 'Alice')...");
            sortedScores.Add(820, "Alice");
            Console.WriteLine($"Success: Added Alice with score 820.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        var naiveDict = new SortedDictionary<ScoreEntry, Player>();
        try
        {
            naiveDict.Add(new ScoreEntry(100, 1), new Player("Test"));
            naiveDict.Add(new ScoreEntry(200, 2), new Player("Test2"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected Error: {ex.GetType().Name}: {ex.Message}\n");
        }

        var sortedScores2 = new SortedDictionary<ScoreEntry, Player>(new ScoreComparer());

        var time = DateTime.Now;
        var p1 = new Player("Alice");
        var p2 = new Player("Bob");
        var p3 = new Player("Charlie");
        var p4 = new Player("David");
        var p5 = new Player("Emma");
        var p6 = new Player("Frank");
        var p7 = new Player("Grace");
        var p8 = new Player("Hannah");
        var p9 = new Player("Ian");
        var p10 = new Player("Jack");

        sortedScores2.Add(new ScoreEntry(450, 4, time.AddMinutes(1)), p1);
        sortedScores2.Add(new ScoreEntry(120, 2, time.AddMinutes(2)), p2);
        sortedScores2.Add(new ScoreEntry(890, 8, time.AddMinutes(3)), p3);
        sortedScores2.Add(new ScoreEntry(230, 3, time.AddMinutes(4)), p4);
        sortedScores2.Add(new ScoreEntry(670, 6, time.AddMinutes(5)), p5);
        sortedScores2.Add(new ScoreEntry(310, 3, time.AddMinutes(6)), p6);
        sortedScores2.Add(new ScoreEntry(990, 10, time.AddMinutes(7)), p7);
        sortedScores2.Add(new ScoreEntry(150, 2, time.AddMinutes(8)), p8);
        sortedScores2.Add(new ScoreEntry(780, 7, time.AddMinutes(9)), p9);
        sortedScores2.Add(new ScoreEntry(540, 5, time.AddMinutes(10)), p10);

        Console.WriteLine("Task 2: Top 3 Scores ");
        foreach (var entry in sortedScores2.Reverse().Take(3))
        {
            Console.WriteLine($"{entry.Value.Name} -> {entry.Key}");
        }

        Console.WriteLine("\nTask 2: Bottom 3 Scores ");
        foreach (var entry in sortedScores2.Take(3))
        {
            Console.WriteLine($"{entry.Value.Name} -> {entry.Key}");
        }

        var toRemove = sortedScores2.FirstOrDefault(kvp => kvp.Value.Name == "Charlie");
        if (toRemove.Key != null)
        {
            sortedScores2.Remove(toRemove.Key);
        }

        Console.WriteLine("\nTask 2: Remaining Players ");
        foreach (var entry in sortedScores2)
        {
            Console.WriteLine($"{entry.Value.Name} -> {entry.Key}");
        }

        var tiedPlayer = new Player("Sam");
        var tiedKey = new ScoreEntry(450, 5, DateTime.Now);
        sortedScores2.Add(tiedKey, tiedPlayer);
        Console.WriteLine($"\nAdded tied score: {tiedPlayer.Name} -> {tiedKey}");

        var replayKey = new ScoreEntry(920, 9, DateTime.Now);
        sortedScores2.Add(replayKey, p1);
        Console.WriteLine($"Added new score for existing player: {p1.Name} -> {replayKey}");

        Console.WriteLine("\nTask 3: PriorityQueue<Player, int> ");
        var EventQueue = new PriorityQueue<Player, int>();
        EventQueue.Enqueue(p1, 3);
        EventQueue.Enqueue(p2, 1);
        EventQueue.Enqueue(p3, 5);
        EventQueue.Enqueue(p4, 2);
        EventQueue.Enqueue(p5, 4);

        while (EventQueue.TryDequeue(out Player? player, out int priority))
        {
            Console.WriteLine($"[Priority {priority}] {player.Name}");
        }

        Console.WriteLine("\nTask 3: Players with the same priority ");
        EventQueue.Enqueue(p6, 2);
        EventQueue.Enqueue(p7, 1);
        EventQueue.Enqueue(p8, 1);
        EventQueue.Enqueue(p9, 3);

        while (EventQueue.TryDequeue(out Player? player, out int priority))
        {
            Console.WriteLine($"[Priority {priority}] {player.Name}");
        }

        Console.WriteLine("\n Task 4: PriorityQueue<Player, Priority> ");
        var EventQueue2 = new PriorityQueue<Player, Priority>();
        EventQueue2.Enqueue(p1, Priority.LowPriority);
        EventQueue2.Enqueue(p2, Priority.HighPriority);
        EventQueue2.Enqueue(p3, Priority.MediumPriority);
        EventQueue2.Enqueue(p4, Priority.LowPriority);
        EventQueue2.Enqueue(p5, Priority.HighPriority);

        while (EventQueue2.TryDequeue(out Player? player, out Priority priority))
        {
            Console.WriteLine($"[{priority}] {player.Name}");
        }

        Console.WriteLine("\nTask 4: Players with the same priority ");
        EventQueue2.Enqueue(p6, Priority.MediumPriority);
        EventQueue2.Enqueue(p7, Priority.HighPriority);
        EventQueue2.Enqueue(p8, Priority.HighPriority);
        EventQueue2.Enqueue(p9, Priority.LowPriority);

        while (EventQueue2.TryDequeue(out Player? player, out Priority priority))
        {
            Console.WriteLine($"[{priority}] {player.Name}");
        }
    }
    
}
public enum Priority
{
    HighPriority,
    MediumPriority,
    LowPriority,
}
