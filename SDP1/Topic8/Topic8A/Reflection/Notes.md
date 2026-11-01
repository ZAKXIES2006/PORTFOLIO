Task 1

When I added the (String, int) entry it just worked with no error. A Hashtable stores every key and value as object, so it has no idea that I only wanted Players as keys. This means there's no compile time type safety, and the mistake only shows up later, like when "NotAPlayer" ended up at the top of my leaderboard. A Dictionary< Player, int> would have refused to compile that line.

When I added Alice a second time it threw an ArgumentException, because every key in a Hashtable has to be unique, just like a Dictionary.

I couldn't use LINQ directly. Hashtable only implements the old non-generic IEnumerable, not IEnumerable<T>, so methods like OrderByDescending aren't available on it. I'd have to call .Cast DictionaryEntry first to turn it into a typed sequence. Instead I copied the entries into a List DictionaryEntry and wrote my own selection sort, which also meant casting each Value back to an int because they're stored as objects.
Build (StringBuilder) was much faster. At 200,000 characters Append took about 1.5 seconds while Build took less than a millisecond, and the gap got bigger the more characters I added.

This is because strings in C# are immutable, so every time I do aOutput += "z" it can't just add a character to the end. It has to create a brand new string and copy every existing character into it. The longer the string gets, the more copying each += does. StringBuilder keeps an internal buffer it can grow, so Append just adds the character to the end without copying everything each time.
he Append (+=) method is O(n^2). In my results, every time the number of characters doubled the time went up about 4 times (pass 10 took 0.34s, pass 20 took 1.58s, and pass 40 took 7.51s). The appendPlot graph curves upwards instead of being a straight line, which is the shape of a quadratic. This makes sense because each += copies the whole string again, so ad=

The StringBuilder method is O(n). When the number of characters doubled, the time only roughly doubled (pass 10 took 0.17ms, pass 20 took 0.32ms, and pass 40 took 0.68ms). The buildPlot graph is roughly a straight line going up, apart from a few small spikes, which is the shape of linear growth. Each Append just adds one character to the end of the buffer, so n characters is n steps.