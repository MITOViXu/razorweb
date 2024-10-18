using System.Text;

var builder = WebApplication.CreateBuilder(args);
var servive = builder.Services;

servive.AddDistributedMemoryCache();
servive.AddDistributedSqlServerCache((option) =>
{
  option.ConnectionString = "Data Source=192.168.1.110, 1433; Initial Catalog=webdb; TrustServerCertificate=True; UID = SA; PWD = Password123";
  option.SchemaName = "dbo";
  option.TableName = "Session";
});
servive.AddSession((option) =>
{
  option.Cookie.Name = "mtoan";
  option.IdleTimeout = new TimeSpan(0, 30, 0);
  //                            hour, minute, seconds
});
var app = builder.Build();
app.UseSession(); // Session middleware
app.MapGet("/readwritesession", async (context) =>
{
  int? count;
  count = context.Session.GetInt32("count");
  if (count == null) count = 0;
  count += 1;
  context.Session.SetInt32("count", count.Value);
  await context.Response.WriteAsync("So lan truy cap : " + count);
});
app.MapGet("/", async (context) =>
{
  context.Response.ContentType = "text/plain; charset=utf-8";
  await context.Response.WriteAsync("Trang web trống");
});

app.Run();
/*
dotnet sql-cache create "Data Source=192.168.1.110, 1433; Initial Catalog=webdb; TrustServerCertificate=True; UID = SA; PWD = Password123" dbo Session;
*/