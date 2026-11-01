using System;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
class Test
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }


    static void Task1()
    {
        Console.WriteLine("Task 1");
        string path = @"./MyTest.txt";

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello");
            sw.WriteLine("World");
        }

        using (StreamReader sr = File.OpenText(path))
        {
            string? s;
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }

        Console.WriteLine("File is at: " + Path.GetFullPath(path));
    }

    //  Task 2 
    static void Task2()
    {
        Console.WriteLine("\nTask 2");
        string path = @"./players.json";

        List<Player> players = new List<Player>
        {
            new Player("Aria"),
            new Player("Bram", 120, 9, 7),
            new Player("Cass", 80, 15, 3),
            new Player("Dov", 95, 11, 6),
            new Player("Esme", 110, 10, 8)
        };

        string jsonString = JsonSerializer.Serialize(players);
        Console.WriteLine(jsonString);

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.Write(jsonString);
        }

        string loadedJson = File.ReadAllText(path);
        List<Player> loadedPlayers = JsonSerializer.Deserialize<List<Player>>(loadedJson)!;

        Console.WriteLine("\nLoaded from disk:");
        foreach (Player p in loadedPlayers)
        {
            Console.WriteLine(p);
        }
    }
    //  Task 3 
    static void Task3()
    {
        Console.WriteLine("\n=== Task 3 ===");
        string path = @"./players_task3.json";

        List<Player> players = new List<Player>
        {
            new Player("Aria"),
            new Player("Bram", 120, 9, 7),
            new Player("Cass", 80, 15, 3),
            new Player("Dov", 95, 11, 6),
            new Player("Esme", 110, 10, 8)
        };

        // Save with one line
        FileWriter(path, players);

        // Load with one line
        List<Player> loadedPlayers = FileReader<List<Player>>(path);

        Console.WriteLine("Loaded with FileReader:");
        foreach (Player p in loadedPlayers)
        {
            Console.WriteLine(p);
        }
    }
    static void Task4()
    {
        Console.WriteLine("\n Task 4 ");
        string path = @"./players_linked.json";

        // 1. Make a LinkedList and add 5 players
        LinkedList<Player> players = new LinkedList<Player>();
        players.AddLast(new Player("Aria"));
        players.AddLast(new Player("Bram", 120, 9, 7));
        players.AddLast(new Player("Cass", 80, 15, 3));
        players.AddLast(new Player("Dov", 95, 11, 6));
        players.AddLast(new Player("Esme", 110, 10, 8));

        // 2. Save it with FileWriter
        FileWriter(path, players);

        // 3. Load it back with FileReader
        LinkedList<Player> loadedPlayers = FileReader<LinkedList<Player>>(path);

        Console.WriteLine("Loaded LinkedList:");
        foreach (Player p in loadedPlayers)
        {
            Console.WriteLine(p);
        }

        // 4. Clean up garbage, then check heap size
        GC.Collect();
        long heapBytes = GC.GetGCMemoryInfo().HeapSizeBytes;

        // 5. Check peak memory of the whole program
        long peakBytes = Process.GetCurrentProcess().PeakWorkingSet64;

        Console.WriteLine($"HeapSizeBytes:    {heapBytes:N0} bytes");
        Console.WriteLine($"PeakWorkingSet64: {peakBytes:N0} bytes");
    }


    static void Task5()
    {
        Console.WriteLine("\n Task 5 ");

        (long listHeap, long listPeak) = MeasureList();
        GC.Collect();
        (long linkedHeap, long linkedPeak) = MeasureLinkedList();

        Console.WriteLine($"List<Player>       HeapSizeBytes: {listHeap,12:N0}   PeakWorkingSet64: {listPeak,14:N0}");
        Console.WriteLine($"LinkedList<Player> HeapSizeBytes: {linkedHeap,12:N0}   PeakWorkingSet64: {linkedPeak,14:N0}");
    }

    static (long, long) MeasureList()
    {
        List<Player> players = new List<Player>();
        for (int i = 0; i < 10_000; i++)
        {
            players.Add(new Player($"Player{i}"));
        }
        FileWriter(@"./players_list.json", players);
        List<Player> loaded = FileReader<List<Player>>(@"./players_list.json");

        GC.Collect();
        long heap = GC.GetGCMemoryInfo().HeapSizeBytes;
        long peak = Process.GetCurrentProcess().PeakWorkingSet64;
        Console.WriteLine($"Loaded {loaded.Count} players into a List");
        return (heap, peak);
    }

    static (long, long) MeasureLinkedList()
    {
        LinkedList<Player> players = new LinkedList<Player>();
        for (int i = 0; i < 10_000; i++)
        {
            players.AddLast(new Player($"Player{i}"));
        }
        FileWriter(@"./players_linkedlist.json", players);
        LinkedList<Player> loaded = FileReader<LinkedList<Player>>(@"./players_linkedlist.json");

        GC.Collect();
        long heap = GC.GetGCMemoryInfo().HeapSizeBytes;
        long peak = Process.GetCurrentProcess().PeakWorkingSet64;
        Console.WriteLine($"Loaded {loaded.Count} players into a LinkedList");
        return (heap, peak);
    }

//task 3 filreaders
        public static void FileWriter<T>(string path, T objectToWrite) where T : class
    {
        string jsonString = JsonSerializer.Serialize(objectToWrite);

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.Write(jsonString);
        }
    }

    public static T FileReader<T>(string path) where T : class
    {
        string jsonString = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }
}

//FILEWRITER AND FILREADER METHOD 