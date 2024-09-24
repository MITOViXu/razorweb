using System.Text;
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS29
{

  class Program
  {
    public class TestAsync01
    {

      public static void WriteLine(string s, ConsoleColor color)
      {
        Console.ForegroundColor = color;
        Console.WriteLine(s);
      }

      public static Task<string> Async1(string thamso1, string thamso2)
      {
        Func<object, string> myfunc = (object thamso) =>
        {
          dynamic ts = thamso;
          for (int i = 1; i <= 10; i++)
          {
            WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3} Tham số {ts.x} {ts.y}",
                ConsoleColor.Green);
            Thread.Sleep(500);
          }
          return $"Kết thúc Async1! {ts.x}";
        };

        Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
        task.Start();

        Console.WriteLine("Async1: Làm gì đó sau khi task chạy");


        return task;
      }

      public static Task Async2()
      {

        Action myaction = () =>
        {
          for (int i = 1; i <= 10; i++)
          {
            WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3}",
                ConsoleColor.Yellow);
            Thread.Sleep(2000);
          }
        };
        Task task = new Task(myaction);
        task.Start();

        Console.WriteLine("Async2: Làm gì đó sau khi task chạy");

        return task;
      }

    }
    // asynchronous (multi thread)
    static void Main(string[] args)
    {
      Console.WriteLine($"{' ',5} {Thread.CurrentThread.ManagedThreadId,3} MainThread");
      Task<string> t1 = TestAsync01.Async1("A", "B");
      Task t2 = TestAsync01.Async2();

      Console.WriteLine("Làm gì đó ở thread chính sau khi 2 task chạy");

      t1.Wait();
      String s = t1.Result;
      TestAsync01.WriteLine(s, ConsoleColor.Red);

      Console.ReadKey();
    }
  }
}