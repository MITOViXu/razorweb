﻿using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using Newtonsoft.Json;
using static System.Console;
namespace CS36
{
  public class Program
  {
    class MyHttpListener
    {
      private HttpListener listener;
      public MyHttpListener(string[] prefixes)
      {
        if (!HttpListener.IsSupported)
        {
          throw new Exception("HttpListener is not supported");
        }
        listener = new HttpListener();
        foreach (string prefix in prefixes) listener.Prefixes.Add(prefix);
      }
      public async Task Start()
      {
        listener.Start();
        WriteLine("Http Server started");
        do
        {
          WriteLine(DateTime.Now.ToLongTimeString() + " waiting a client connect");
          var context = await listener.GetContextAsync();
          ProcessRequest(context);
        } while (listener.IsListening);
      }
      async Task ProcessRequest(HttpListenerContext context)
      {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;
        WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");
        var outputStream = response.OutputStream;
        switch (request.Url.AbsolutePath)
        {
          case "/":
            {
              var bufer = Encoding.UTF8.GetBytes("<h1>Xin chao cac ban</h1>");
              await outputStream.WriteAsync(bufer, 0, bufer.Length);
              response.ContentLength64 = bufer.Length;
            }
            break;
          case "/json":
            {
              // return type
              response.Headers.Add("Content-Type", "application/json");
              response.Headers.Add("Content-Type", "text/html");
              var product = new
              {
                Name = "Macbook Pro",
                Price = 2000,
              };
              var p = JsonConvert.SerializeObject(product);
              var bufer = Encoding.UTF8.GetBytes(p);
              await outputStream.WriteAsync(bufer, 0, bufer.Length);
              response.ContentLength64 = bufer.Length;
            }
            break;
          case "/image":
            {
              // return type
              response.Headers.Add("Content-Type", "image/png");
              var bufer = await File.ReadAllBytesAsync("image.png");
              await outputStream.WriteAsync(bufer, 0, bufer.Length);
              response.ContentLength64 = bufer.Length;
            }
            break;
        }
        outputStream.Close();
      }

    }
    public static async Task Main(string[] args)
    {
      var server = new MyHttpListener(new string[] { "http://*:8080/" });
      await server.Start();
    }
  }
}