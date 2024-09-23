using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS27
{
  class Program
  {
    static void Main(string[] args)
    {
      // FIFO
      Queue<string> cachoso = new Queue<string>();
      cachoso.Enqueue("Ho so 1");
      cachoso.Enqueue("Ho so 2");
      cachoso.Enqueue("Ho so 3");

      foreach (string s in cachoso)
      {
        WriteLine(s);
      }
      string hoso = cachoso.Dequeue();
      WriteLine("Ho so duoc lay ra: " + hoso);

      // LIFO
      Stack<string> stack = new Stack<string>();
      stack.Push("Hang 1");
      stack.Push("Hang 2");
      stack.Push("Hang 3");
      stack.Push("Hang 4");
      foreach (string s in stack)
      {
        WriteLine(s);
      }
      string stack1 = stack.Pop();
      WriteLine("stack duoc lay ra: " + stack1);

      LinkedList<string> cacbaihoc = new LinkedList<string>();
      var bh1 = cacbaihoc.AddFirst("Bai hoc 1");
      var bh3 = cacbaihoc.AddLast("Bai hoc 4");
      var bh2 = cacbaihoc.AddAfter(bh1, "Bai hoc 2");
      LinkedListNode<string> bha = cacbaihoc.AddAfter(bh2, "Bai hoc 3");
      foreach (string s in cacbaihoc)
      {
        WriteLine(s);
      }
      WriteLine();
      WriteLine("Node after bha: " + bha.Next.Value);
      WriteLine();

      HashSet<int> set = new HashSet<int>() { 1, 2, 3, 4, 4 };
      HashSet<int> set2 = new HashSet<int>() { 2, 2, 3, 4, 4 };
      set.IntersectWith(set2);
      foreach (int s in set)
      {
        WriteLine(s);
      }
    }
  }
}