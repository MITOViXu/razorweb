using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<MyBlogContext>(options =>
{
    string connection = configuration.GetConnectionString("MyBlogContext");
    options.UseSqlServer(connection);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
/*

    CREATE, READ, UPDATE, DELETE (CRUD)

    dotnet aspnet-codegenerator razorpage -m Article -dc MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries

*/