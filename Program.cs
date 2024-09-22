using static System.Console;
namespace CS16
{
  class Program
  {
    class Product<A>
    {
      A ID;
      public void setID(A _id)
      {
        this.ID = _id;
      }
      public void PrintInf()
      {
        WriteLine($"ID = {ID}");
      }
    }
    static void Swap<T>(ref T x, ref T y)
    {
      T temp;
      temp = x;
      x = y;
      y = temp;
    }
    static void Main(string[] args)
    {
      string a = "Abc", b = "Xyz";
      WriteLine($@"Before   swap {a} {b}");
      Swap<string>(ref a, ref b);
      WriteLine($@"After    swap {a} {b}");

      Product<string> sanpham1 = new Product<string>();
      sanpham1.setID("sanpham1");
      sanpham1.PrintInf();

      Product<int> sanpham2 = new Product<int>();
      sanpham2.setID(123);
      sanpham2.PrintInf();

      // represent lists of elements
      List<int> list1 = new List<int>();
      List<string> list2 = new List<string>();
      list1.Add(1);
      list1.Add(2);
      list1.Add(3);
      list2.Add("Hello");
      list2.Add("Any");
      list2.Add("One");
      foreach (int i in list1)
      {
        WriteLine(i);
      }
      foreach (string i in list2)
      {
        WriteLine(i);
      }
      // LIFO
      Stack<int> stack = new Stack<int>();
      // FIFO
      Queue<int> q = new Queue<int>();
    }
  }
}