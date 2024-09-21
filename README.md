# StringBuilder and string in C# 🐨🐽

```
using System.Text;

namespace CS11
{
  class Program
  {
    static void Main(string[] args)
    {
      // working the same way but the performace will be bad
      string hoten;
      hoten = "Nguyen";
      hoten += " Van2 Minh Toan";
      hoten = hoten.Replace("Van2", "Van");
      Console.WriteLine(hoten);

      //   For the best performace
      StringBuilder hoten2 = new StringBuilder();
      hoten2.Append("Nguyen ");
      hoten2.Append(" Van2 Minh Toan");
      hoten2.Replace("Nguyen  Van2", "Nguyen Van");
      Console.WriteLine(hoten2);
    }
  }
}
```
