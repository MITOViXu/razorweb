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