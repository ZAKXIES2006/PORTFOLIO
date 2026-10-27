
My Dijkstra's starts byby  setting every node's distance to infinity except Start which is 0, then puts Start in a priority queue. Each loop it takes out the node with the smallest distance so far. For each neighbour it adds the edge weight to the current distance, and if that's shorter than what we had saved for that neighbour, it updates the distance, saves current as the neighbour's parent, and adds the neighbour to the queue. It stops when it pulls out END. Then I follow the parents back from END to Start and reverse it to get the path. Because the bee edges cost 5, going around them (total 10) ends up cheaper than going through them, so it avoids the bees, unlike BFS which just took the fewest steps.

q2
Dijkstra's is O(v+E  log |V|) with a priority queue. It's slower than BFS/DFS's O(V + E) because every time we add or remove from the priority queue it has to keep things sorted by distance, which costs log |V|. BFS and DFS just use a normal queue or stack where adding and removing is instant, but they don't care about weights so they can't find the cheapest path.

Task 2

 Claude was used by e. My prompt was roughly "write a complete C# console app that runs Dijkstra's on the horse/bees graph and works with dotnet run". It worked first time (one round) and gave the same path, Start -> ... -> END with a cost of 10. (Note: I also used Claude for help on my Task 1 version.)

The biggest difference is that the AI version doesn't use Node or Graph classes at all. It stores the graph as a Dictionary of node names to a list of (neighbour, weight) tuples, built from one big edge list.

Better: it's more robust. It skips "stale" entries in the priority queue using a visited set, so it never processes the same node twice, and it handles the case where there's no path at all instead of crashing. The edge list is also really compact and easy to check.

Worse: it's harder to read. Short names like d, w and nd, tuples instead of proper classes, and everything is strings, so a typo in a node name wouldn't be caught by the compiler. It also doesn't reuse our Graph/Node classes, so it couldn't run BFS/DFS on the same graph.