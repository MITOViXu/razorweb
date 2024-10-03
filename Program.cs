using static System.Console;
using System.IO;
namespace CS32
{

  //  Attribute
  // [AttributeName(thamso)]

  /*
    Description
    - Detail info
  */

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // Describe the place that is attribute using for
  class MotaAttribute : Attribute
  {
    public string thongtin { get; set; }
    public MotaAttribute(string thongtin)
    {
      this.thongtin = thongtin;
    }
  }
  [Mota("Lop chua thong tin ve user tren he thong")]
  class User
  {
    [Mota("Ten nguoi dung")]
    public string Name { get; set; }
    [Mota("Tuoi nguoi dung")]
    public int Age { get; set; }
    [Mota("So dien thoai")]
    public string PhoneNumber { get; set; }
    [Mota("Email nguoi dung")]
    public string Email { get; set; }
    public User(string name, int age, string phoneNumber, string email)
    {
      Name = name;
      Age = age;
      PhoneNumber = phoneNumber;
      Email = email;
    }
    public User()
    {
      Name = "";
      Age = 0;
      PhoneNumber = "";
      Email = "";
    }
    [Obsolete("Phuong thuc nay da duoc su dung ")]
    public void PrintInfo() => WriteLine(Name);
  }
  public class Program
  {
    // Type -> class, struct, ... int, bool
    // Attribute
    // Reflection : Information about data type, time execute
    static void Main(string[] args)
    {

      // INTRODUCTION
      int a = 1;
      Type t1 = typeof(int);
      WriteLine();
      WriteLine(a.GetType().FullName);
      WriteLine();
      int[] b = { 1, 2, 3, 4 };
      Type check = b.GetType();
      WriteLine("Kieu du lieu: " + check.FullName);
      WriteLine();
      WriteLine("--------Cac thuoc tinh: ");
      check.GetProperties().ToList().ForEach((System.Reflection.PropertyInfo p) => WriteLine(p.Name));
      WriteLine("--------Cac truong du lieu: ");
      check.GetFields().ToList().ForEach((System.Reflection.FieldInfo p) => WriteLine(p.Name));
      WriteLine("KHONG CO");
      WriteLine();


      // PRACTICING
      WriteLine("--------Cac truong du lieu User: ");
      User user = new User("Mtoan", 21, "0947566433", "mtoan@gmail.com");
      var properties = user.GetType().GetProperties();
      foreach (var p in properties)
      {
        var name = p.Name;
        var value = p.GetValue(user);

        // We know the properties's name and the value
        WriteLine($@"{name}: {value}");
      }
      WriteLine();
      WriteLine();
      WriteLine("--------Cac truong du lieu User theo attribute: ");
      var properties2 = user.GetType().GetProperties();
      foreach (var p in properties2)
      {
        foreach (var i in p.GetCustomAttributes(false))
        {
          MotaAttribute mota = i as MotaAttribute;
          if (mota != null)
          {

            WriteLine($"{p.Name.PadRight(20)} - {mota.thongtin.PadRight(20)}:  {p.GetValue(user)?.ToString().PadRight(20)}");
          }
        }
      }
      WriteLine();
      WriteLine();


    }
  }
}