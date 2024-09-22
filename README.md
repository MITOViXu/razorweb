# Null and nullable 👀🦿🦾🎆🧨

```
using static System.Console;
namespace CS18
{
  class Program
  {
    class Abc
    {
      public void XinChao() => WriteLine("Xin chao C$");
    }
    static void Main(string[] args)
    {
      Abc a = new Abc();
      a = null;
      a?.XinChao();
      a = new Abc();
      a?.XinChao();

      int? age;
      age = null;
      age=10;
      if (age.HasValue) WriteLine(age.Value);

    }
  }
}
```
