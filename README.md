# Using HttpListener for creating simple Server

## Using HttpListener

```cs
try
      {
        var server = new HttpListener();

        // Using http protocol, listen all connection come from IP address and listen on 8080 port
        server.Prefixes.Add("http://*:8080/");
        server.Start();
        WriteLine("Server Http Start");
        do
        {
          var context = await server.GetContextAsync();
          WriteLine("Client connected");
          var response = context.Response;
          response.Headers.Add("Content-Type", "text/html");
          var outputStream = response.OutputStream;

          var html = "<h1>Hello anh yeu em</h1>";
          var bytes = Encoding.UTF8.GetBytes(html);
          await outputStream.WriteAsync(bytes, 0, bytes.Length);
          outputStream.Close();

        } while (server.IsListening);
      }
      catch (System.Exception e)
      {
        WriteLine("Error: "+e.Message);
      }
```

_Out put_

![alt text](/image.png)

##
