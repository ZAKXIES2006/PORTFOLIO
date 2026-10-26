using GraphDemo;

var graph = new Graph<string>();

// Nodes from the map. Bee squares have (BEES) in their name.
var start = new Node<string>("Start");
var a = new Node<string>("A");
var b = new Node<string>("B (BEES)");
var c = new Node<string>("C");
var d = new Node<string>("D (BEES)");
var e = new Node<string>("E (BEES)");
var f = new Node<string>("F");
var g = new Node<string>("G");
var h = new Node<string>("H");
var i = new Node<string>("I (BEES)");
var j = new Node<string>("J (BEES)");
var k = new Node<string>("K");
var l = new Node<string>("L");
var m = new Node<string>("M");
var n = new Node<string>("N");
var end = new Node<string>("END");

// Edges: 1 = normal grass, 5 = walking over bees
graph.AddEdge(end, l, 1);
graph.AddEdge(l, i, 5);
graph.AddEdge(i, f, 5);
graph.AddEdge(f, c, 1);
graph.AddEdge(c, a, 1);
graph.AddEdge(m, j, 5);
graph.AddEdge(j, g, 5);
graph.AddEdge(g, d, 5);
graph.AddEdge(d, start, 5);
graph.AddEdge(n, k, 1);
graph.AddEdge(k, h, 1);
graph.AddEdge(h, e, 5);
graph.AddEdge(e, b, 5);
graph.AddEdge(l, m, 1);
graph.AddEdge(m, n, 1);
graph.AddEdge(i, j, 5);
graph.AddEdge(j, k, 5);
graph.AddEdge(f, g, 1);
graph.AddEdge(g, h, 1);
graph.AddEdge(c, d, 5);
graph.AddEdge(d, e, 5);
graph.AddEdge(a, start, 1);
graph.AddEdge(start, b, 5);

Console.WriteLine(graph.ToString());

Console.WriteLine(" BFS (ignores weights)");
graph.BreadthFirstSearch(start, end);
Console.WriteLine();

Node<string> target = end;

var distanceList = new Dictionary<Node<string>, int>();
foreach (var node in graph.Nodes)
{
    distanceList[node] = int.MaxValue;
}
distanceList[start] = 0;

var priorityQueue = new PriorityQueue<Node<string>, int>();
var parents = new Dictionary<Node<string>, Node<string>?>();
parents[start] = null;
priorityQueue.Enqueue(start, 0);

while (priorityQueue.Count > 0)
{
    var current = priorityQueue.Dequeue();

    if (current == target)
    {
        break;
    }

    foreach (var neighbour in current.Edges)
    {
        int newDistance = distanceList[current] + neighbour.Value;

        if (newDistance >= distanceList[neighbour.Key])
        {
            continue;
        }

        distanceList[neighbour.Key] = newDistance;
        parents[neighbour.Key] = current;
        priorityQueue.Enqueue(neighbour.Key, newDistance);
    }
}

var path = new List<string>();
Node<string>? step = target;
while (step != null)
{
    path.Add(step.Data);
    step = parents[step];
}
path.Reverse();

Console.WriteLine(" Dijkstra's (uses weights)");
Console.WriteLine("Path: " + string.Join(" -> ", path));
Console.WriteLine($"Total distance: {distanceList[target]}");
