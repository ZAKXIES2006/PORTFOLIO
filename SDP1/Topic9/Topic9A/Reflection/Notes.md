q1
The graph we built is undirected, because AddEdge adds the connection both ways, so B is in A’s edges and A is in B’s edges. It’s also acyclic, since there’s no way to loop back to a node without going back over the same edge, which basically makes it a tree (9 nodes, 8 edges, all connected). It’s unweighted too, because the edges are just references to other nodes and don’t store any cost or distance.


Two other data structures that are secretly graphs are heaps and tries. A heap (like the one behind a priority queue) is just a complete binary tree, and since trees are graphs, heaps are graphs too. A trie is a tree used for storing words, like in autocomplete, where each node is a letter and each edge leads to the next possible letter.

q2
We need to keep track of visited nodes because our graph is undirected, so every node links back to the one it came from. Without a visited list, BFS would keep bouncing between nodes like A → B → A → B forever, and in the adjusted graph it could get stuck going around the G–H loop. Tracking visited nodes stops infinite loops and stops us checking the same node more than once.

In the adjusted graph my BFS takes A → C → F → I instead of A → B → E → H → I. This is because BFS goes layer by layer, so it reaches I through F in 3 steps before it ever gets to the 4-step route through H. This means BFS always finds the shortest path (fewest edges) in an unweighted graph.

The complexity of BFS is O(|V| + |E|), where |V| is the number of vertices (nodes) and |E| is the number of edges. It’s this because every node gets added to the queue and checked once, and every edge gets looked at when we loop through each node’s neighbours. So the time it takes grows with the size of the whole graph.

q3
For the initial graph DFS was faster. It only checked A, C, F before finding I, while BFS checked 8 nodes. DFS dives straight down one branch, and I happened to be at the end of the C branch which it explored first.

For the adjusted graph DFS still checked fewer nodes (4 vs 8), but it found a longer path, A -> C -> F -> H -> I, instead of BFS's A -> C -> F -> I. So DFS can get there faster depending on which branch it picks first, but BFS always finds the shortest path in an unweighted graph.

Both have the same complexity, O(|V| + |E|), because in the worst case they both visit every node once and look at every edge once. The only difference is the order they visit things in (queue vs stack), not the total amount of work.