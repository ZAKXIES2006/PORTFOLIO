using System.Text;
 
namespace GraphDemo
{

    public class Graph<T>
    {
        public HashSet<Node<T>> Nodes { get; set; }
 
 // basiclaly stores every node in the graph
        public Graph()
        {
            Nodes = new HashSet<Node<T>>();
        }
        //links both nodes together
                        public void AddEdge(Node<T> fromNode, Node<T> toNode)
        {
            Nodes.Add(fromNode);
            Nodes.Add(toNode);
 
            fromNode.Edges.Add(toNode);
            toNode.Edges.Add(fromNode);
        }
         // Breadth First Search from start to target, prints Checked and the Path
        public void BreadthFirstSearch(Node<T> start, Node<T> target)
        {
            var checkedNodes = new List<Node<T>>();             
            var queued = new Queue<Node<T>>();         
            //records where we came from         
            var parents = new Dictionary<Node<T>, Node<T>?>();  
            bool found = false;

            queued.Enqueue(start);
            parents[start] = null;

            while (queued.Count > 0)
            {
                var current = queued.Dequeue();

                if (current == target)
                {
                    found = true;
                    break;
                }
                checkedNodes.Add(current);

                foreach (var neighbour in current.Edges)
                {
                
                    if (checkedNodes.Contains(neighbour) || queued.Contains(neighbour))
                    {
                        continue;
                    }

                    queued.Enqueue(neighbour);
                    parents[neighbour] = current;
                }
            }

            Console.WriteLine($"Checked: {string.Join(", ", checkedNodes)}");

            if (found)
            {
                
                var path = new List<Node<T>>();
                Node<T>? step = target;
                while (step != null)
                {
                    path.Add(step);
                    step = parents[step];
                }
                path.Reverse();

                Console.WriteLine($"Found {target}! Path: {string.Join(" -> ", path)}");
            }
            else
            {
                Console.WriteLine($"{target} was not found.");
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
 
            sb.AppendLine($"Graph contains {Nodes.Count} nodes:");
            sb.AppendLine(string.Join(", ", Nodes));
            sb.AppendLine();
            sb.AppendLine("Edges:");
 
            foreach (var node in Nodes)
            {
                sb.AppendLine($"  {node} -> {string.Join(", ", node.Edges)}");
            }
 
            return sb.ToString();
        }
        
    }

}
 