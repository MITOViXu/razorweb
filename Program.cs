var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.UseFirstMiddleware();
app.UseSecondMiddleware();
app.Run();
