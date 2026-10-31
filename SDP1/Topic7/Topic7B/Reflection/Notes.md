SortedDictionary is backed by a red-black tree (self-balancing binary search tree), which I found just by checking the official Microsoft docs for the class. When I tried adding a duplicate score it threw an ArgumentException because keys have to be totally unique in a dictionary so the tree knows where to store and find them without conflicts. Basically the difference between the two is that SortedSet only stores individual sorted items without extra data, like keeping a simple list of unique high scores, while SortedDictionary maps a sorted key to a separate value, like pairing those scores directly with the player names so you can look up who actually got each score.
Task 3

A PriorityQueue is backed by an array-based min-heap (a 4-ary heap in .NET), which I found in the Microsoft docs for PriorityQueue<TElement, TPriority>. That's why the lowest priority number always comes out first.

When I enqueued two players with the same priority (Grace and Hannah both at 1), both were kept and both came out before the priority 2 player. The order between players with the same priority isn't guaranteed though, it's not first-in-first-out, which you can see in Task 4 where David came out before Alice even though Alice was added first.

A PriorityQueue allows duplicates because it isn't a set. The priority only decides the order things come out, it isn't a unique key, so many items can share the same priority. A SortedSet is a set, so every item has to be unique and it ignores anything that compares as equal to something already in it.

Task 4

We didn't need IComparer or IComparable for the enum because enums are stored as ints underneath (HighPriority = 0, MediumPriority = 1, LowPriority = 2) and already implement IComparable, so C# knows how to compare them. That's why HighPriority comes out first.

If we used a struct with an int Priority property instead, we would need to implement IComparer or IComparable. C# doesn't know how to compare a custom struct, so it would throw the same "must implement IComparable" error as BankAccount did, even though the struct only has one int inside it.