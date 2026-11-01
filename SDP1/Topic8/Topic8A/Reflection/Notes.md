Task 1

When I added the (String, int) entry it just worked with no error. A Hashtable stores every key and value as object, so it has no idea that I only wanted Players as keys. This means there's no compile time type safety, and the mistake only shows up later, like when "NotAPlayer" ended up at the top of my leaderboard. A Dictionary< Player, int> would have refused to compile that line.

When I added Alice a second time it threw an ArgumentException, because every key in a Hashtable has to be unique, just like a Dictionary.

I couldn't use LINQ directly. Hashtable only implements the old non-generic IEnumerable, not IEnumerable<T>, so methods like OrderByDescending aren't available on it. I'd have to call .Cast DictionaryEntry first to turn it into a typed sequence. Instead I copied the entries into a List DictionaryEntry and wrote my own selection sort, which also meant casting each Value back to an int because they're stored as objects.
Build (StringBuilder) was much faster. At 200,000 characters Append took about 1.5 seconds while Build took less than a millisecond, and the gap got bigger the more characters I added.

This is because strings in C# are immutable, so every time I do aOutput += "z" it can't just add a character to the end. It has to create a brand new string and copy every existing character into it. The longer the string gets, the more copying each += does. StringBuilder keeps an internal buffer it can grow, so Append just adds the character to the end without copying everything each time.