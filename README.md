# Exception 🎇🎆🎟🎞🛒🎭

```
using static System.Console;
using static System.ConsoleColor;
using static System.Math;
namespace CS25
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        string path = "1.txt";
        string s = File.ReadAllText(path);
        WriteLine(s);
      }
      catch (FileNotFoundException file)
      {
        WriteLine(file.Message);
      }
      catch (System.Exception)
      {
        WriteLine("Loi file");
        throw;
      }
    }
  }
}
```
