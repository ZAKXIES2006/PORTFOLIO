
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
 
 