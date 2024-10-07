using static System.Console;
namespace CS34
{

  public class Program
  {
    static void Main(string[] args)
    {
      string url = "https://phimmoichill.com/xem/deadpool-va-wolverine-a1-tap-full-pm118754";
      var uri = new Uri(url);
      var uriType = typeof(Uri);
      WriteLine();
      uriType.GetProperties().ToList().ForEach(p =>
      {
        WriteLine($"{p.Name,15} {p.GetValue(uri)}");
      });
      WriteLine();
      WriteLine();
      WriteLine();
      WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
      WriteLine();
      WriteLine();
    }
  }
}
