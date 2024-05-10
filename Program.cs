using Album.Mail;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyBlogContextConnection") ?? throw new InvalidOperationException("Connection string 'MyBlogContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
// Dang ky Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyBlogContext>()
                .AddDefaultTokenProviders();
// builder.Services.AddDefaultIdentity<AppUser>()
//                 .AddEntityFrameworkStores<MyBlogContext>()
//                 .AddDefaultTokenProviders();
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<MyBlogContext>(options =>
{
    string connection = configuration.GetConnectionString("MyBlogContext");
    options.UseSqlServer(connection);
});

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MyBlogContext>();
builder.Services.AddOptions();
var mailSettings = configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddSingleton<IEmailSender, SendMailService>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

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
app.UseAuthentication();
app.UseAuthorization();
SignInManager<AppUser> s;
UserManager<AppUser> m;

app.MapRazorPages();
IdentityUser user;
IdentityDbContext context;
app.Run();
/*

    CREATE, READ, UPDATE, DELETE (CRUD)

    dotnet aspnet-codegenerator razorpage -m Article -dc MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries

    Identity: 
     - Authentication: Xác thực danh tính
     - Authorization: Xác thực quyền truy cập.
     - Quản lí user: Sign Up, User, Role ...

    /Identity/Account/Login
    /Identity/Account/Manage
    
    Generate code để tùy biến

    dotnet aspnet-codegenerator identity -dc MyBlogContext
*/