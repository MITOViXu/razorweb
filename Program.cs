var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
service.AddRazorPages().AddRazorPagesOptions(option =>
{
    // Change Razor site storage directory
    option.RootDirectory = "/Pages";
    // Change site address to anohter name
    option.Conventions.AddPageRoute("/FirstPage", "trangdau.html");
});
service.Configure<RouteOptions>(route =>
{
    route.LowercaseUrls = true;
});
var app = builder.Build();

app.MapRazorPages();
// FirstPage 
app.MapGet("/", () => "Hello World!");


app.Run();

/*
    Razor page (.cshtml) = html + c#
    Enginge Razor -> bien dich cshtml -> Response
*/