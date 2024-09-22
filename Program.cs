using static System.Console;
using static System.Math;
namespace CS19
{
  // virtual method
  // Defined in basic class and can be overwritten by inherit class

  // abstract can not be used to create object classes
  abstract class Product
  {
    protected double Price { set; get; }
    public virtual void ProductInfo()
    {
      WriteLine($"Gia san pham {Price}");
    }
    public abstract void InfoProduct();

    public void Test() => ProductInfo();
  }
  // Inherited class base on basic class 
  class Iphone : Product
  {
    public Iphone() => Price = 500;
    // override - method overloading
    public override void ProductInfo()
    {
      WriteLine("Dien thoai iphone");
      // if we want to call method is defined in basic class
      base.ProductInfo();
    }
    // implement inherited abstract member 'Product.InfoProduct()'
    public override void InfoProduct()
    {
      WriteLine("Iphone san pham moi");
    }
  }

  // interface - not be used to declare the structure of class, but not supposed to create object, used to be basic class for inheritant
  interface IHinhHoc
  {
    public double TinhChuVi();
    public double TinhDienTich();

  }
  class HinhChuNhat : IHinhHoc
  {
    public double a { set; get; }
    public double b { set; get; }
    public HinhChuNhat(double a, double b)
    {
      this.a = a;
      this.b = b;
    }

    public double TinhChuVi()
    {
      return 2 * (this.a + this.b);
    }

    public double TinhDienTich()
    {
      return this.a * this.b;
    }
  }
  class HinhTron : IHinhHoc
  {
    public double r { set; get; }
    public HinhTron(double r) => this.r = r;
    public double TinhChuVi()
    {
      return 2 * r * PI;
    }

    public double TinhDienTich()
    {
      return r * r * PI;
    }
  }
  public class Program
  {
    public static void Main(string[] args)
    {
      Iphone i = new Iphone();
      i.Test();
      WriteLine();
      Iphone product = new Iphone();
      product.InfoProduct();
      WriteLine();
      HinhChuNhat h = new HinhChuNhat(5, 6);
      WriteLine($"Chu vi hinh chu nhat: {h.TinhChuVi()}");
      WriteLine($"Dien tich hinh chu nhat: {h.TinhDienTich()}");
      WriteLine();
      IHinhHoc hinhvuong = new HinhChuNhat(5, 5);
      WriteLine($"Chu vi hinh vuong: {hinhvuong.TinhChuVi()}");
      WriteLine($"Dien tich hinh vuong: {hinhvuong.TinhDienTich()}");
      WriteLine();
      IHinhHoc hinhtron = new HinhTron(2);
      WriteLine($"Chu vi hinh tron: {hinhtron.TinhChuVi()}");
      WriteLine($"Dien tich hinh tron: {hinhtron.TinhDienTich()}");
      WriteLine();
    }
  }
}