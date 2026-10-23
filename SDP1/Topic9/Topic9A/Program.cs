
using GraphDemo;
 

var graph = new Graph<string>();
 

var A = new Node<string>("A");
var B = new Node<string>("B");
var C = new Node<string>("C");
var D = new Node<string>("D");
var E = new Node<string>("E");
var F = new Node<string>("F");
var G = new Node<string>("G");
var H = new Node<string>("H");
var I = new Node<string>("I");
 

graph.AddEdge(A, B);
graph.AddEdge(A, C);
graph.AddEdge(B, D);
graph.AddEdge(B, E);
graph.AddEdge(C, F);
graph.AddEdge(D, G);
graph.AddEdge(E, H);
graph.AddEdge(F, I);
 

Console.WriteLine(graph.ToString());
var target = I;
 
Console.WriteLine(" BFS on initial graph");
graph.BreadthFirstSearch(A, target);
Console.WriteLine();
 

graph.AddEdge(G, H);
graph.AddEdge(H, I);
 
Console.WriteLine(" BFS on adjusted graph ");
graph.BreadthFirstSearch(A, target);
 
 
Console.WriteLine();

// DFS uses a fresh copy of the original graph (the BFS one was adjusted)
var dfsGraph = new Graph<string>();
var n = BuildInitialGraph(dfsGraph);

Console.WriteLine(" DFS on initial graph");
dfsGraph.DepthFirstSearch(n["A"], n["I"]);
Console.WriteLine();

// adjusted graph for DFS: D-E-F, E-H, F-H, G-H, H-I
dfsGraph.AddEdge(n["D"], n["E"]);
dfsGraph.AddEdge(n["E"], n["F"]);
dfsGraph.AddEdge(n["F"], n["H"]);
dfsGraph.AddEdge(n["G"], n["H"]);
dfsGraph.AddEdge(n["H"], n["I"]);

Console.WriteLine(" DFS on adjusted graph");
dfsGraph.DepthFirstSearch(n["A"], n["I"]);

// builds the original A-I graph from Task 1 and returns the nodes by name
static Dictionary<string, Node<string>> BuildInitialGraph(Graph<string> g)
{
    var nodes = new Dictionary<string, Node<string>>();
    foreach (string name in new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" })
    {
        nodes[name] = new Node<string>(name);
    }

    g.AddEdge(nodes["A"], nodes["B"]);
    g.AddEdge(nodes["A"], nodes["C"]);
    g.AddEdge(nodes["B"], nodes["D"]);
    g.AddEdge(nodes["B"], nodes["E"]);
    g.AddEdge(nodes["C"], nodes["F"]);
    g.AddEdge(nodes["D"], nodes["G"]);
    g.AddEdge(nodes["E"], nodes["H"]);
    g.AddEdge(nodes["F"], nodes["I"]);
    return nodes;
}
