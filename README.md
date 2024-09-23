# List and SortedList 🎇🎆🎟🎞🛒🎭

```
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS25
{
  class Product
  {
    public string Name { get; set; }
    public double Price { get; set; }
    public int ID { get; set; }
    public string Origin { get; set; }
  }
  class Program
  {
    static void Main(string[] args)
    {
      List<string> list = new List<string>();

      list.Add("1");
      list.Add("2");
      list.Add("3");
      list.AddRange(new string[] { "4", "5", "6", "7" });

      WriteLine();
      foreach (string s in list)
      {
        Write(" " + s + " ");
      }
      WriteLine();
      WriteLine();

      List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      var n = ints.Find((e) =>
      {
        return e % 2 == 0;
      });
      var n2 = ints.FindAll((e) =>
      {
        return e % 2 == 0;
      });
      WriteLine(n);
      WriteLine();
      foreach (int i in n2)
      {
        Write(i + " ");

      }
      WriteLine();
      WriteLine();
      ForegroundColor = Red;
      List<Product> products = new List<Product>() {
          new Product() { Name = "Iphone X", Origin="China", Price = 1000, ID = 1 },
          new Product() { Name = "Samsung", Origin="China", Price = 2000, ID = 2 },
          new Product() { Name = "Huawei", Origin="China", Price = 3000, ID = 3 },
          new Product() { Name = "Oppo", Origin="China", Price = 4000, ID = 4 }
        };
      foreach (Product pro in products)
      {
        WriteLine(pro.Name + " " + pro.Origin + " " + pro.Price);
      }
      ResetColor();
      WriteLine();
      WriteLine();
      ForegroundColor = Green;
      // SortedList
      SortedList<string, Product> product2 = new SortedList<string, Product>();
      product2["Huawei"] = new Product() { Name = "Huawei", Origin = "China", ID = 1, Price = 1000 };
      WriteLine(product2["Huawei"].Name);
      ResetColor();
      WriteLine();
      WriteLine();
    }
  }
}
```
