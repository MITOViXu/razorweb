using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef
{

  public class ProductDbContext : DbContext
  {
    public static  readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
      {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddConsole();
      }
    );
    public DbSet<Product> products { get; set; }
    const string connectString = @"Data Source=192.168.1.110, 1433; 
                                  Initial Catalog=data01; 
                                  UID=sa;
                                  PWD=Password123;
                                  Encrypt=False;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseLoggerFactory(loggerFactory);
      optionsBuilder.UseSqlServer(connectString);
    }
  }
}