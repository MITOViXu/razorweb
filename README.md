# Namespcae and partial organization c# 😎🦿👣🤺⛷🤼‍♂️

## Program.cs
```
using System.Threading.Tasks.Dataflow;
using MyNameSpace;
using Xyz = MyNameSpace.Abc;
using static System.Console;
using static System.Math;
using static Sanpham.Product;
using Sanpham;
namespace CS15
{
  class Program
  {
    static void Main(string[] args)
    {

      WriteLine("");

      Class1.XinChao();

      Xyz.Class1.XinChao();

      WriteLine(PI);

      Product product = new Product();
      product.name = "Iphone";
      product.price = 1000;
      product.description = "Day la ipad";
      product.manuFactory = new ManuFactory();
      product.manuFactory.name = "Google";

      WriteLine(product.GetInfor());

      WriteLine("");
    }
  }
}
```
## Product1.cs
```
namespace Sanpham
{
  public partial class Product
  {
    public string name { get; set; }
    public decimal price { get; set; }
    public string GetInfor()
    {
      return @$"{name} / {price} : {this.description} : NSX {this.manuFactory.name}";
    }
  }
}
```

## Product2.cs
```
namespace Sanpham
{
  // merging 2 definition of namespace Sampham with "partial" key word
  public partial class Product
  {
    public ManuFactory manuFactory { set; get; }
    public class ManuFactory()
    {
      public string name { set; get; }
      public string addr { set; get; }
    }
    public string description { set; get; }
    public void Abc()
    {

    }
  }
}
```

## mynamespace.cs
```
namespace MyNameSpace
{
  // class, struct, enum, interface, ... namespace
  public class Class1
  {
    public static void XinChao()
    {
      Console.WriteLine("Xin Chao tu class 1");
    }

  }
  namespace Abc
  {
    public class Class1
    {
      public static void XinChao()
      {
        Console.WriteLine("Xin Chao tu Class 1 / Abc");
      }
    }
  }
}
```