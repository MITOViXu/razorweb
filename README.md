# Middleware, pipleline and processing flow in HttpContext 🎍🎪🎢🎭🧶

## FirstMiddleware.cs

```cs
public class FirstMiddleware
{
    private readonly RequestDelegate _next;

    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine(context.Request.Path);
        context.Items.Add("data", "\nXin chao ban tro lai voi " + context.Request.Path);
        await _next(context);
    }
}
```

## SecondMiddleware.cs

```cs
public class SecondMiddleware
{
  private readonly RequestDelegate _next;
  public SecondMiddleware(RequestDelegate next)
  {
    _next = next;
  }
  public async Task InvokeAsync(HttpContext context)
  {
    if (context.Request.Path == "/xxx.html")
    {
      await context.Response.WriteAsync("\nBan khong duoc truy cap");
      return;
    }
    else
    {
      await context.Response.WriteAsync("Ban duoc truy cap ");
      var data = context.Items["data"];
      if (data != null) await context.Response.WriteAsync((string)data);
      await _next(context);
    }
  }
}
```

## UseMiddleware.cs

```cs
public static class UseMiddleware
{
  public static void UseFirstMiddleware(this IApplicationBuilder app){
    app.UseMiddleware<FirstMiddleware>();
  }
  public static void UseSecondMiddleware(this IApplicationBuilder app){
    app.UseMiddleware<SecondMiddleware>();
  }
}
```

## Program.cs

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.UseFirstMiddleware();
app.UseSecondMiddleware();
app.Run();

```
