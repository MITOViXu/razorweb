using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class MyBlogContext : IdentityDbContext<AppUser>
{
  public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
  {
    // ...
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
      var tablenams = entity.GetTableName();
      if (tablenams.StartsWith("AspNet"))
      {
        entity.SetTableName(tablenams.Substring(6));
      }
    }
  }

  public DbSet<Article> articles { get; set; }
}