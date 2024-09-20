

namespace CS03
{
  // When we want to manage withdraw processing
  class Student : IDisposable
  {
    public string name;
    public Student(string name)
    {
      this.name = name;
      Console.WriteLine("Khoi tao ho va ten " + name);
    }
    ~Student()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("HUY " + name);
      Console.ResetColor();
    }

    public void Dispose()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("HUY (DISPOSE) " + name);
      Console.ResetColor();
    }
  }
  class Program
  {
    static void Test()
    {
      using Student sv = new Student("Ten");
    }
    static void Main(string[] args)
    {
      // Vukhi sungluc = new Vukhi();
      // Vukhi sungtruong = new Vukhi("Sung truong");
      // Console.WriteLine(sungluc.name);
      // sungluc.name = "Hello kitty";
      // // Console.WriteLine(sungluc.name);
      // sungluc.ThietLapDoSatThuong(5);
      // Console.Write("Sung luc sat thuong: ");
      // sungluc.Tancong();
      // sungluc.Satthuong = 15;
      // Console.WriteLine(sungluc.Satthuong);
      // sungluc.Noisanxuat = "Hoa Ky";
      // Console.WriteLine(sungluc.Noisanxuat);
      Student student;
      for (int i = 0; i < 100; i++)
      {
        student = new Student("Sinnh vien " + i);
        student = null;
      }
      // student = null;
      using (Student student1 = new Student("Ten sinh vien"))
      {

      }

      Test();
      //  Memory recovery, The withdrawal period is determined by .NET
      GC.Collect();
    }
  }
}