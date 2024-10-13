# Entity Framework establish relationship 1 - many 🎄🎋🎆🧨🎉🎃

## Install EF packages

```bash
dotnet add package System.Data.SqlClient
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.Extensions.Logging.Console
```

## Install Proxy

```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

```cs
// Fluent API are executed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      WriteLine("OnModelCreating");

      //Fluent-API
      modelBuilder.Entity<Product>(entity =>
      {
        // entity => fluent api
        // Table mapping
        // change table name of Product
        entity.ToTable("Sản phẩm");

        // PK
        entity.HasKey(p => p.ProductId);

        // Index
        // If we query sanpham by gia, the speed will improve
        entity.HasIndex(p => p.Price)
              .HasDatabaseName("index-sanpham-price");

        // Relative: relation one - many
        entity.HasOne(p => p.Category)
              .WithMany() // Category khong co Property ~ Sanpham
              .HasForeignKey("CateId") // Name the Foreign key
              .OnDelete(DeleteBehavior.Cascade) // When delete the one side, the many side will be deleted too.
              .HasConstraintName("Khoa_ngoai_Sanpham_Category");
        entity.HasOne(p => p.Category2)
              .WithMany(c => c.Products)
              .HasForeignKey("CateId2")
              .OnDelete(DeleteBehavior.NoAction);

        // Name the column Tensanpham, Fluent APi will override the attribute
        entity.Property(p => p.Name)
              .HasColumnName("title")
              .HasColumnType("nvarchar")
              .HasMaxLength(60)
              .IsRequired(false)
              .HasDefaultValue("Ten san pham mac dinh");
      });
      modelBuilder.Entity<CategoryDetail>(entity =>
      {
        // in CategoryDatail
        entity.HasOne(d => d.category)
              // int Category
              .WithOne(c => c.categoryDetail)
              .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
              .OnDelete(DeleteBehavior.Cascade);
      }
      );
    }
```
