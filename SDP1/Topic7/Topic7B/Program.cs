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
        //if scores are not equal, we have a winner
        if (stageComp != 0) return stageComp;

        return x.AchievedAt.CompareTo(y.AchievedAt);
    }
}
class Program
{
    static void Main()
    {
        var sortedScores = new SortedDictionary<int, string>();
//integers is the key, name is the value. 
//.take()take sthe bottom 3 values... whilst .reverse().take() takes the top... 
//keys must be unique 



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
        Console.WriteLine("--- Top 3 Scores ---");
        foreach (var entry in sortedScores.Reverse().Take(3))
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        // 3. this 3ill print the bottom 3 scores
        Console.WriteLine("\n--- Bottom 3 Scores ---");
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
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected Error: {ex.Message}\n");
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

        Console.WriteLine("--- Task 2: Top 3 Scores ---");
        foreach (var entry in sortedScores2.Reverse().Take(3))
        {
            Console.WriteLine($"{entry.Value.Name} -> {entry.Key}");
        }

        Console.WriteLine("\n--- Task 2: Bottom 3 Scores ---");
        foreach (var entry in sortedScores2.Take(3))
        {
            Console.WriteLine($"{entry.Value.Name} -> {entry.Key}");
        }

        var toRemove = sortedScores2.FirstOrDefault(kvp => kvp.Value.Name == "Charlie");
        if (toRemove.Key != null)
        {
            sortedScores2.Remove(toRemove.Key);
        }

        Console.WriteLine("\n--- Task 2: Remaining Players ---");
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
    }
    
}