using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using static System.Console;
namespace CS34
{

  public class Program
  {
    static void ShowHeaders(HttpResponseHeaders headers)
    {
      WriteLine("Cac header");
      WriteLine();
      WriteLine();
      foreach (var header in headers)
      {
        WriteLine($"{header.Key}:{header.Value}");
      }
    }
    public static async Task<string> GetWebContent(string url)
    {
      try
      {
        WriteLine();
        var HttpClient = new HttpClient();
        HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(url);
        string html = await httpResponseMessage.Content.ReadAsStringAsync();
        return html;
      }
      catch (Exception e)
      {
        WriteLine(e);
        return "Loi";
      }
    }
    public static async Task<byte[]> DownloadDataBytes(string url)
    {
      try
      {
        WriteLine();
        var HttpClient = new HttpClient();
        HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(url);
        byte[] bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
        return bytes;
      }
      catch (Exception e)
      {
        WriteLine(e);
        return null;
      }
    }

    public static async Task DownloadStream(string url, string filename)
    {
      try
      {
        WriteLine();
        var HttpClient = new HttpClient();
        HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(url);

        // Return a Stream type
        var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        int sizeBuffer = 500;
        var buffer = new byte[sizeBuffer];
        bool end = false;
        using var streamWrite = File.OpenWrite(filename);
        do
        {
          int numBytes = await stream.ReadAsync(buffer, 0, sizeBuffer);
          WriteLine("Num: "+numBytes);
          if (numBytes == 0)
          {
            end = true;
          }
          else
          {
            await streamWrite.WriteAsync(buffer, 0, numBytes);
          }
        } while (!end);
      }
      catch (Exception e)
      {
        WriteLine(e);
      }
    }

    static async Task Main(string[] args)
    {
      // Read web's content
      string url = "https://phimmoichill.com/xem/deadpool-va-wolverine-a1-tap-full-pm118754";
      // Http Request - HttpClient (GET/POST/)
      WriteLine();
      WriteLine();

      string html = await GetWebContent(url);
      // WriteLine(html);
      // Save image file
      var url2 = "https://i.mydramalist.com/d0oKBz_2f.png";
      // var bytes = await DownloadDataBytes(url2);
      string filename = "leejoobin.jpg";
      var stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
      // stream.Write(bytes, 0, bytes.Length);
      await DownloadStream(url2, "leejoobin2.jpg");
      WriteLine();
      WriteLine();
    }
  }
}
