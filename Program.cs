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