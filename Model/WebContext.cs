using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CS43
{
  public class WebContext : DbContext
  {
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ArticleTag> ArticleTags { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(@"
          Data Source = 192.168.1.110, 1433;
          Initial Catalog=webdb;
          UID =sa;
          TrustServerCertificate=True;
          PWD=Password123
      ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<ArticleTag>(entity =>
      {
        entity.HasIndex(articleTag => new { articleTag.ArticleId, articleTag.TagId })
              .IsUnique();
      });
    }
  }
}