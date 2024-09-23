# Lambda 👀🦿🦾🎆🧨

```
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS21
{
  /*
    Lambda - anonymous function
      1)
        (int a, int b) => methods;
      2)
        (parameter) => {
          expression;
          return expression;
        }

  */
  class Program
  {
    static void Main(string[] args)
    {
      // lambda using for delegate
      Action<string> thongbao;
      thongbao = (string s) => WriteLine(s);
      WriteLine();
      thongbao("Hello anh em xa doan nha");
      thongbao.Invoke("Xin chao anh em xa nha nha");
      WriteLine();

      // Another way
      Action thongbao2;
      WriteLine();
      thongbao2 = () => WriteLine("Cach thong bao thu hai");
      thongbao2();
      thongbao2.Invoke();
      WriteLine();

      WriteLine();
      Action welCome;
      welCome = () => WriteLine("Without argument");
      welCome();
      WriteLine();

      WriteLine();
      Action<string> welCome2;
      welCome2 = s => WriteLine($"With {s} argument");
      welCome2("String");
      WriteLine();

      WriteLine();
      Action<string, string> welCome3;
      welCome3 = (s1, s2) =>
      {
        ForegroundColor = Green;
        WriteLine($"Welcome {s1} and {s2}");
        ResetColor();
      };
      welCome3("Bob", "Alice");
      WriteLine();

      // delegate with return value
      Func<int, int, int> sum;
      sum = (num1, num2) =>
      {
        return num1 + num2;
      };
      ForegroundColor = Blue;
      WriteLine("Total is : " + sum(1, 2));
      ResetColor();
      WriteLine();

      // Using lambda by .NET library
      int[] mang = [1, 2, 3, 4, 5, 6, 7, 8];
      var kq = mang.Select(x => x * 2);
      foreach (var k in kq)
      {
        Write(k + " ");
      }

      WriteLine();
      WriteLine();
    }
  }
}
```
