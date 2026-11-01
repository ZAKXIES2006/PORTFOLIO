Task 1

When I added the (String, int) entry it just worked with no error. A Hashtable stores every key and value as object, so it has no idea that I only wanted Players as keys. This means there's no compile time type safety, and the mistake only shows up later, like when "NotAPlayer" ended up at the top of my leaderboard. A Dictionary< Player, int> would have refused to compile that line.

When I added Alice a second time it threw an ArgumentException, because every key in a Hashtable has to be unique, just like a Dictionary.

I couldn't use LINQ directly. Hashtable only implements the old non-generic IEnumerable, not IEnumerable<T>, so methods like OrderByDescending aren't available on it. I'd have to call .Cast DictionaryEntry first to turn it into a typed sequence. Instead I copied the entries into a List DictionaryEntry and wrote my own selection sort, which also meant casting each Value back to an int because they're stored as objects.