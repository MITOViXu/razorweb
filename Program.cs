using System;
namespace CS12
{
  class Program
  {
    // Enumeration type Enum
    enum HOCLUC
    {
      Kem = 10,
      TrungBinh = 11,
      Kha = 12,
      Gioi = 13
    }

    // Struc is pass by value, while Class is pass by Reference
    public struct Product
    {
      public string name;
      public double price;
      public string GetInfo()
      {
        return $"Ten san pham: {name}, gia: {price}";
      }
      // constructor
      public Product(string _name, double _price)
      {
        name = _name;
        this.price = _price;
      }
      public string Info
      {
        get { return $"\nSan pham {name} duoc ban voi gia {price}"; }
      }

    }
    static void Main(string[] args)
    {
      Product sanpham1;
      sanpham1.name = "Iphone";
      sanpham1.price = 1000;

      Product sanpham2 = new Product("Nokia", 900);
      Console.WriteLine(sanpham1.GetInfo());
      Console.WriteLine(sanpham2.GetInfo());
      Console.WriteLine(sanpham1.Info);

      HOCLUC hocluc;
      hocluc = HOCLUC.Kha;
      switch (hocluc)
      {
        case HOCLUC.Kem:
          Console.WriteLine("Hoc luc kem");
          break;
        case HOCLUC.Gioi:
          Console.WriteLine("Hoc luc gioi");
          break;
        case HOCLUC.TrungBinh:
          Console.WriteLine("Hoc luc trung binh");
          break;
        case HOCLUC.Kha:
          Console.WriteLine("Hoc luc kha");
          break;
      }
      int so = (int)hocluc;
      Console.WriteLine(so);
    }

  }
}