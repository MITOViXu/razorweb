using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using static System.Console;
namespace CS35
{
  public class Program
  {
    public class MyHttpClientHandler : HttpClientHandler
    {
      public MyHttpClientHandler(CookieContainer cookie_container)
      {

        CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
        AllowAutoRedirect = false;                // không cho tự động Redirect
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        UseCookies = true;
      }
      protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                   CancellationToken cancellationToken)
      {
        Console.WriteLine("Bất đầu kết nối " + request.RequestUri.ToString());
        // Thực hiện truy vấn đến Server
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine("Hoàn thành tải dữ liệu");
        return response;
      }
    }

    public class ChangeUri : DelegatingHandler
    {
      public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                             CancellationToken cancellationToken)
      {
        var host = request.RequestUri.Host.ToLower();
        Console.WriteLine($"Check in  ChangeUri - {host}");
        if (host.Contains("google.com"))
        {
          // Đổi địa chỉ truy cập từ google.com sang github
          request.RequestUri = new Uri("https://github.com/");
        }
        // Chuyển truy vấn cho base (thi hành InnerHandler)
        return base.SendAsync(request, cancellationToken);
      }
    }


    public class DenyAccessFacebook : DelegatingHandler
    {
      public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

      protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                   CancellationToken cancellationToken)
      {

        var host = request.RequestUri.Host.ToLower();
        Console.WriteLine($"Check in DenyAccessFacebook - {host}");
        if (host.Contains("facebook.com"))
        {
          var response = new HttpResponseMessage(HttpStatusCode.OK);
          response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
          return await Task.FromResult<HttpResponseMessage>(response);
        }
        // Chuyển truy vấn cho base (thi hành InnerHandler)
        return await base.SendAsync(request, cancellationToken);
      }
    }
    public static async Task Main(string[] args)
    {
      string url = "https://www.facebook.com/xuanthulab";

      CookieContainer cookies = new CookieContainer();

      // TẠO CHUỖI HANDLER
      var bottomHandler = new MyHttpClientHandler(cookies);              // handler đáy (cuối)
      var changeUriHandler = new ChangeUri(bottomHandler);
      var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); // handler đỉnh

      // Khởi tạo HttpCliet với hander đỉnh chuỗi hander
      var httpClient = new HttpClient(denyAccessFacebook);

      // Thực hiện truy vấn
      httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
      httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
      HttpResponseMessage response = await httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      string htmltext = await response.Content.ReadAsStringAsync();

      Console.WriteLine(htmltext);

    }
  }
}