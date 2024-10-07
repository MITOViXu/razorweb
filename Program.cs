using System.Net;
using System.Net.NetworkInformation;
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
      var hostname = Dns.GetHostName();
      WriteLine("Host name: " + hostname);
      WriteLine("Website's host name: " + uri.Host);

      var ip = Dns.GetHostEntry(uri.Host);
      WriteLine();
      ip.AddressList.ToList().ForEach(i => WriteLine(i));
      WriteLine();

      // ping 

      var ping = new Ping();
      var pingReply = ping.Send("phimmoichill.com");
      WriteLine(pingReply.Status);
      if (pingReply.Status == IPStatus.Success) WriteLine(pingReply.RoundtripTime + "\n" + pingReply.Address);

      // Http Request - HttpClient (GET/POST/)
      

      WriteLine();
      WriteLine();
    }
  }
}
