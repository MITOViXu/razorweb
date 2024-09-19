
namespace CS01
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Xin chao C#");
      Abc.XinChao();
      Console.WriteLine(Tong(2,3));
      Console.WriteLine(Tong(2,Tong(3,5)));
    }
    /// <summary>
    /// Phuong thuc tong cua 2 so nguyen
    /// </summary>
    /// <param name="a">so nguyen 1</param>
    /// <param name="b">so nguyen 2</param>
    /// <returns>Tong a + b</returns>
    static int Tong(int a, int b)
    {
      return a + b;
    }
  }
  class Abc
  {
    public static void XinChao()
    {
      Console.WriteLine("Xin chao den voi C#");
    }
  }
}

namespace MyNameSpace
{
  class Abc
  {

  }
}