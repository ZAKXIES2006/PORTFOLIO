using System.Collections;
using System.Diagnostics;
using System.Text;

Console.WriteLine("TASK 1 - Hashtable");

Hashtable scoreHash = new Hashtable();

Player alice = new Player("Alice");
Player bob = new Player("Bob");
Player charlie = new Player("Charlie");
Player diana = new Player("Diana");
Player ethan = new Player("Ethan");

scoreHash.Add(alice, 420);
scoreHash.Add(bob, 870);
scoreHash.Add(charlie, 150);
scoreHash.Add(diana, 990);
scoreHash.Add(ethan, 560);
Console.WriteLine($"Added 5 players. Count = {scoreHash.Count}");

try
{
    scoreHash.Add("NotAPlayer", 999);
    Console.WriteLine("Added a string key with no error - Hashtable has no type safety.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error adding string key: {ex.Message}");
}

try
{
    scoreHash.Add(alice, 100);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error adding duplicate key: {ex.GetType().Name}");
}

List<DictionaryEntry> entries = new List<DictionaryEntry>();
foreach (DictionaryEntry entry in scoreHash)
{
    entries.Add(entry);
}

for (int i = 0; i < entries.Count - 1; i++)
{
    int maxIndex = i;
    for (int j = i + 1; j < entries.Count; j++)
    {
        if ((int)entries[j].Value! > (int)entries[maxIndex].Value!)
        {
            maxIndex = j;
        }
    }
    (entries[i], entries[maxIndex]) = (entries[maxIndex], entries[i]);
}

Console.WriteLine("\nScores (highest first):");
foreach (DictionaryEntry entry in entries)
{
    string name = entry.Key is Player p ? p.Name : $"{entry.Key} (not a Player!)";
    Console.WriteLine($"{name}: {entry.Value}");
}

Console.WriteLine("\nTASK 2 - Append vs Build");

Stopwatch watch = new Stopwatch();
int[] sizes = { 10_000, 50_000, 100_000, 200_000 };

foreach (int size in sizes)
{
    string aOutput = "";
    watch.Restart();
    for (int i = 0; i < size; i++)
    {
        aOutput += "z";
    }
    watch.Stop();
    double appendTime = watch.Elapsed.TotalSeconds;

    StringBuilder bOutput = new();
    watch.Restart();
    for (int i = 0; i < size; i++)
    {
        bOutput.Append("z");
    }
    watch.Stop();
    double buildTime = watch.Elapsed.TotalSeconds;

    Console.WriteLine($"{size,8:N0} chars  |  Append: {appendTime,8:F4}s  |  Build: {buildTime,8:F6}s");
}
