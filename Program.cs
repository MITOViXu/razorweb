using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS24
{
  class CountNumber
  {
    public static int number = 0;
    public static void Info()
    {
      WriteLine("So lan truy cap la: " + number);
    }
    public void Count()
    {
      CountNumber.number++;
    }
  }
  class Student
  {
    public readonly string name = "Nguyen Van A";
    public Student(string name)
    {
      this.name = name;
    }
  }
  class Vector
  {
    double x;
    double y;
    public Vector(double x, double y)
    {
      this.y = y;
      this.x = x;
    }
    public void Info()
    {
      WriteLine("(" + x + ", " + y + ")");
    }
    // vector <- vector + vector
    public static Vector operator +(Vector v, Vector v2)
    {
      double x = v.x + v2.x;
      double y = v.y + v2.y;
      return new Vector(x, y);
    }
    // Indexer
    public double this[int index]
    {
      set
      {
        switch (index)
        {
          case 0:
            x = value;
            break;
          case 1:
            y = value;
            break;
          default:
            throw new Exception("Chi so sai");
            break;
        }
      }
      get
      {
        switch (index)
        {
          case 0:
            return x;
          case 1:
            return y;
          default:
            throw new Exception("Chi so sai");
            break;
        }
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      CountNumber c1 = new CountNumber();
      CountNumber c2 = new CountNumber();
      c1.Count();
      c2.Count();
      CountNumber.Info();

      Student student = new Student("Nguyen Van A");
      WriteLine("Ten sinh vien: " + student.name);

      Vector vector = new Vector(2, 3);
      Vector vector1 = new Vector(3, 4);
      vector.Info();
      vector1.Info();
      Vector vector3 = vector + vector1;
      vector3.Info();
      WriteLine();
      Vector vector4 = new Vector(3, 4);
      vector4[0] = 100;
      vector4.Info();
    }
  }
}