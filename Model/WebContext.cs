using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CS43
{
  public class WebContext : DbContext
  {
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(@"
          Data Source = 192.168.1.110, 1433;
          Initial Catalog=shopdata;
          UID =sa;
          PWD=Password123
      ");
    }
  }
}