using System.Text;
using static System.Console;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ShowOptions", async (context) =>
{
  var configuration = context.RequestServices.GetService<IConfiguration>();
  var testOption = configuration.GetSection("TestOptions").Get<Testoptions>();
  var opt_key = testOption.opt_key1;
  var opt_key21 = testOption.opt_key2.k1;
  var opt_key22 = testOption.opt_key2.k2;
  var content = new StringBuilder();
  content.Append("\nOption: " + opt_key + " " + opt_key21 + " " + opt_key22 + " ");
  await context.Response.WriteAsync(content.ToString());
});
app.Run();
