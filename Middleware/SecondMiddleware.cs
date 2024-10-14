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