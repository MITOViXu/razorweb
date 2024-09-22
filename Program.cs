using static System.Console;
using static System.ConsoleColor;

// delegate (Type) variable = method 

namespace CS20
{
  class Program
  {
    static void Info(string s)
    {
      ForegroundColor = Green;
      WriteLine(s);
      ResetColor();
    }
    static void Warning(string s)
    {
      ForegroundColor = Red;
      WriteLine(s);
      ResetColor();
    }
    public delegate void ShowLog(string message);
    static void Tong(int a, int b, ShowLog log)
    {
      int kq = a + b;
      log?.Invoke($"Tong la: {kq}");
    }
    static void Main(string[] args)
    {
      ShowLog log = null;
      // log = Info;
      if (log != null) log("Xin chao");
      log?.Invoke("Xin chao Abc");

      log = Info;

      if (log != null) log("Xin chao");
      log?.Invoke("Xin chao Abc");

      log = Warning;
      log?.Invoke("Xin chao warning");
      WriteLine();
      ShowLog log2 = null;

      log2 += Info;
      log2?.Invoke("Xin chao log2");
      log2 += Warning;
      log2?.Invoke("Xin chao log2 Warning");

      WriteLine();

      // Action, Func: delegate - generic 
      Action action; // ~ delegate void KIEU();
      Action<string, int> action1; // ~ delegate void KIEU(string s, int i);
      Action<string> action2; // ~ delegate void KIEU(string s)
      action2 = Warning;
      WriteLine();
      action2.Invoke("action2");
      action2 += Info;
      action2.Invoke("action2 after add Info");
      WriteLine();

      // Using Func is similar to Action but need to have a return value
      // return int value but have no parameter
      Func<int> f1; // ~ delegate int KIEU();

      // reiceive string, double value and return string value
      Func<string, double, string> f2; // ~ delegate string KIEU(string a, double s);
      Tong(4, 5, Info);

    }
  }
}