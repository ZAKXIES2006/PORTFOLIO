
namespace GraphDemo
{
 
  
    public class Node<T>
    {
   
        public T Data { get; set; }

                public Dictionary<Node<T>, int> Edges { get; set; }
 
        public Node(T data)
        {
            Data = data;
            Edges = new Dictionary<Node<T>, int>();
        }
 
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
    }
}
 