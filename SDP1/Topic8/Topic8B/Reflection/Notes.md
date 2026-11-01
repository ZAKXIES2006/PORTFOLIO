What happens if the text file already exists when you write to it?
It gets overwritten. File.CreateText wipes the old contents and starts fresh, so the previous text is lost.
What does the @ symbol before the quoted string mean?
It makes a verbatim string, which means backslashes are treated as normal characters rather than escape codes.
You should wrap them in using. It automatically closes and disposes the reader/writer when the block ends, which flushes the data to the file and releases the file. Without it the file can stay locked, and text you wrote might not actually be saved until the object is cleaned up later.

StreamReader reads the file a bit at a time (line by line in my code), which is better for big files because it doesn't load everything into memory. File.ReadAllText reads the whole file into one string in one go, which is simpler but uses more memory for large files.

Task 2

The ! is the null-forgiving operator. Deserialize can technically return null, and ! tells the compiler "trust me, this won't be null" so it stops giving a nullable warning. It doesn't actually check anything at runtime.

System.Text.Json only serialises public properties. If the properties aren't public they're just left out of the JSON, so when you load it back those values are ARE missing and you get the defaults instead. That's why the Player class had to be changed to have public Health, Attack and Defence.

Task 3

where T : class is a constraint that means T has to be a reference type (a class, a List, a LinkedList, etc). You can't call FileWriter or FileReader with a value type like int or a struct.

Task 4

The Garbage Collector automatically frees memory used by objects that nothing references any more, so we don't have to manually free memory like in C or C++.

It knows the current heap size because the GC is the one that allocates and manages the managed heap, so it keeps track of how much is in use.

GC.Collect() forces a garbage collection to happen straight away instead of waiting for the runtime to decide, so the heap size we measure afterwards doesn't include old garbage.

On my Mac PeakWorkingSet64 always came out as 0, because .NET doesn't support that property on macOS. Normally it would be much bigger than HeapSizeBytes, because the working set is all the memory the whole process uses (the .NET runtime, loaded code and libraries, the stack, etc), and it's the peak (highest ever) rather than the current amount. HeapSizeBytes is only the managed heap where our objects live.

Task 5

The LinkedList used more memory (about 8.37 MB vs 7.77 MB for the List).

This is is because a List stores its items in one array, so each Player only costs one reference in that array. A LinkedList wraps every Player in its own LinkedListNode object, which has its own object overhead plus references to the Next node, the Previous node and the list itself. With 10,000 players that extra node per item adds up.