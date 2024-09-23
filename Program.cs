using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS23
{
  // extension method 
  static class Abc
  {
    public static void Print(this string s, ConsoleColor color)
    {
      ForegroundColor = color;
      WriteLine(s);
      ResetColor();
    }
  }
  class Program
  {

    static void Main(string[] args)
    {
      "HEllo".Print(Red);
    }
  }
}