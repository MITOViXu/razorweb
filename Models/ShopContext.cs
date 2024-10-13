using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Console;
namespace ef
{

  public class ShopContext : DbContext
  {
    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
      {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddConsole();
      }
    );
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { set; get; }
    public DbSet<CategoryDetail> CategoryDetails { set; get; }
    const string connectString = @"Data Source=192.168.1.110, 1433; 
                                  Initial Catalog=shopdata; 
                                  UID=sa;
                                  PWD=Password123;
                                  Encrypt=False;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      // optionsBuilder.UseLoggerFactory(loggerFactory);
      optionsBuilder.UseSqlServer(connectString);

      // Auto loading all reference 
      // optionsBuilder.UseLazyLoadingProxies();
      WriteLine("OnConfiguring");
    }
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

    // Tạo database
    public async Task CreateDatabase()
    {
      String databasename = Database.GetDbConnection().Database;

      Console.WriteLine("Tạo " + databasename);
      bool result = await Database.EnsureCreatedAsync();
      string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
      Console.WriteLine($"CSDL {databasename} : {resultstring}");
    }

    // Xóa Database
    public async Task DeleteDatabase()
    {
      String databasename = Database.GetDbConnection().Database;
      Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
      string input = ReadLine() ?? string.Empty;

      // // Hỏi lại cho chắc
      if (input?.ToLower() == "y")
      {
        bool deleted = await Database.EnsureDeletedAsync();
        string deletionInfo = deleted ? "đã xóa" : "không xóa được";
        Console.WriteLine($"{databasename} {deletionInfo}");
      }
    }
    // Chèn dữ liệu mẫu
    public async Task InsertSampleData()
    {
      // Thêm 2 danh mục vào Category
      // var cate1 = new Category() { Name = "Cate1", Description = "Description1" };
      // var cate2 = new Category() { Name = "Cate2", Description = "Description2" };
      // await AddRangeAsync(cate1, cate2);
      // await SaveChangesAsync();

      // // Thêm 5 sản phẩm vào Products
      // await AddRangeAsync(
      //     new Product() { Name = "Sản phẩm 1", Price = 12, Category = cate2 },
      //     new Product() { Name = "Sản phẩm 2", Price = 11, Category = cate2 },
      //     new Product() { Name = "Sản phẩm 3", Price = 33, Category = cate2 },
      //     new Product() { Name = "Sản phẩm 4(1)", Price = 323, Category = cate1 },
      //     new Product() { Name = "Sản phẩm 5(1)", Price = 333, Category = cate1 }

      // );
      await AddAsync(new Product() { Name = "Iphone X", Price = 12, CateId = 1 });
      await SaveChangesAsync();
      // Các sản phầm chèn vào
      foreach (var item in products)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"ID: {item.ProductId}");
        stringBuilder.Append($"tên: {item.Name}");
        stringBuilder.Append($"Danh mục {item.CateId}({item?.Category?.Name})");
        Console.WriteLine(stringBuilder);
      }

      // ID: 1tên: Sản phẩm 2Danh mục 2(Cate2)
      // ID: 2tên: Sản phẩm 1Danh mục 2(Cate2)
      // ID: 3tên: Sản phẩm 3Danh mục 2(Cate2)
      // ID: 4tên: Sản phẩm 4(1)Danh mục 1(Cate1)
      // ID: 5tên: Sản phẩm 5(1)Danh mục 1(Cate1)

    }
  }
}