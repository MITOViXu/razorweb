namespace CS02
{
  class Program
  {
    static void Main(string[] args)
    {
      float c;
      c = (float)12.12;
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.Title = "Vi du su dung Console";
      Console.WriteLine(c);
      Console.ResetColor();
      Console.WriteLine("Welcome to C#");
    }
  }
}