
namespace GraphDemo
{
 
  
    public class Node<T>
    {
   
        public T Data { get; set; }

                public HashSet<Node<T>> Edges { get; set; }
 
        public Node(T data)
        {
            Data = data;
            Edges = new HashSet<Node<T>>();
        }
 
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
    }
}
 