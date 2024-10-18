var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*

If we want to send Mail, we must to have a server host 
Mail Server - smtp
Smtp

*/

app.MapGet("/", () => "Hello World!");
app.MapGet("/Test", async (context) =>
{
  var mess = await MailUtils.SendMail("mtoansecond@gmail.com", "mtoansecond@gmail.com", "TEST", "Xin chao mtoan");
  await context.Response.WriteAsync(mess);
});
app.MapGet("/TestGmail", async (context) =>
{
  var mess = await MailUtils.SendGMail("mtoan@gmail.com", "minhtoan250503@gmail.com", "TEST", "Xin chao mtoan", "mtoan@gmail.com", "hello");
  await context.Response.WriteAsync(mess);
});
app.Run();
