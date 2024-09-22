using System.Formats.Tar;
using static System.Console;
namespace CS17
{
  class Program
  {
    // Anonymous 
    // Object - attribute - READ ONLY
    // new {attrname1 = value1, atrname2 = value2}


    class Sinhvien
    {
      public string HoTen { get; set; }
      public int Namsinh { get; set; }
      public string Noisinh { get; set; }
      public Sinhvien(string hoTen, int namsinh, string noisinh)
      {
        HoTen = hoTen;
        Namsinh = namsinh;
        Noisinh = noisinh;
      }
      public Sinhvien()
      {
        WriteLine("Hello cac ban");
      }
    }
    
    // Dynamic
    class Student
    {
      public string Name { get; set; }
      public void Hello()
      {
        WriteLine("Hello cac ban: " + Name);
      }
    }
    static void PrintInfo(dynamic obj)
    {
      obj.Name = "Hallo";
      obj.Hello();
    }

    static void Main(string[] args)
    {
      var sanpham = new
      {
        Ten = "Iphone 8",
        Gia = 1000,
        NamSx = 2008
      };
      WriteLine("");
      WriteLine(sanpham.Ten);
      WriteLine(sanpham.Gia);
      WriteLine("");

      List<Sinhvien> cacsinhvien = new List<Sinhvien>(){
        new Sinhvien("Nguyen van A", 1990, "Chau Doc"),
        new Sinhvien("Nguyen van B", 1991, "Tan Chau"),
        new Sinhvien("Nguyen van C", 1992, "Vinh Xuong"),
        new Sinhvien("Nguyen van D", 1993, "Phu Loc"),
        new Sinhvien("Nguyen van F", 1994, "Vinh Hoa"),
        new Sinhvien("Nguyen van G", 1995, "Long An"),
        new Sinhvien("Nguyen van H", 1996, "Tan An"),
      };
      List<Sinhvien> cacsinhvien2 = new List<Sinhvien>(){
        new Sinhvien(){HoTen ="Dan", Namsinh=1990, Noisinh="Binh Nhuong"},
        new Sinhvien(){HoTen ="Meo", Namsinh=1991, Noisinh="Binh Duong"},
        new Sinhvien(){HoTen ="Thin", Namsinh=1992, Noisinh="Binh Dinh"},
      };
      WriteLine("");
      foreach (var c in cacsinhvien)
      {
        Write(c.HoTen + " ");
        Write(c.Namsinh + " ");
        Write(c.Noisinh + " ");
        WriteLine("");
      }
      WriteLine("");
      foreach (var c in cacsinhvien2)
      {
        Write(c.HoTen + " ");
        Write(c.Namsinh + " ");
        Write(c.Noisinh + " ");
        WriteLine("");
      }
      WriteLine("");
      var ketqua = from sv in cacsinhvien where sv.HoTen == "Nguyen van A" select sv;
      foreach (var k in ketqua)
      {
        WriteLine("");
        WriteLine(k.HoTen + " " + k.Namsinh + " " + k.Noisinh);
      }
      WriteLine("");

      var ketqua2 = from sv in cacsinhvien
                    where (sv.HoTen.Contains("Nguyen van") && sv.Noisinh.Contains("Tan") && sv.Namsinh <= 2000)
                    select new
                    {
                      ten = sv.HoTen,
                      ns = sv.Noisinh,
                      nam = sv.Namsinh
                    };

      WriteLine("Second Linq");

      foreach (var k in ketqua2)
      {
        WriteLine(k.ten + " " + k.nam + " " + k.ns);
      }

      WriteLine("");

      Student student1 = new Student();

      PrintInfo(student1);

      WriteLine("");
    }
  }
}