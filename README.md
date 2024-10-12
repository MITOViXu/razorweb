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

**Category.cs**

```cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
  [Table("Category")]
  public class Category
  {
    [Key]
    [Column("SBD")]
    public int CategoryId { get; set; }
    [Required]
    [Column("Tên danh mục", TypeName = "ntext")]
    [StringLength(100)]
    public string Name { get; set; }
    [Column("Mô tả", TypeName = "ntext")]
    public string Description { get; set; }
    public Category(string name, string description)
    {
      Name = name;
      Description = description;
    }
    // Collect Navigation
    // auto load use Lazyload, we must use virtual
    public virtual List<Product>? Products { get; set; }
  }
}
```

**Product.cs**

```cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Console;
namespace ef
{
  [Table("Product")]
  public class Product
  {
    [Key]
    public int ProductId { set; get; }

    [Required]
    [StringLength(50)]
    public string? Name { set; get; }

    [Column(TypeName = "money")]
    public decimal Price { set; get; }

    // Sinh FK (CategoryID ~ Cateogry.CategoryID) ràng buộc đến PK key của Category
    public int CateId { set; get; }

    // Reference Navigation -> Foreign key (1 - many)

    [ForeignKey("CateId")]
    // auto load using LazyLoad, we must use virtual
    public virtual Category? Category { set; get; }


    public void PrintInfo()
    {
      WriteLine("\nID: " + ProductId + ", Name: " + Name + ", Price: " + Price + ", CateID: " + CateId);
    }
  }
}
```

**ShopContext.cs**

```cs
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
      optionsBuilder.UseLazyLoadingProxies();
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
```

**Program.cs**

```cs
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using ef;
using Microsoft.EntityFrameworkCore;
using static System.Console;
namespace CS41
{
  public partial class Program
  {
    static void CreateDatabase()
    {
      using DbContext dbContext = new ShopContext();
      string name = dbContext.Database.GetDbConnection().Database;
      var result = dbContext.Database.EnsureCreated();
      if (result) WriteLine("Khoi tao thanh cong CSDL: " + name);
      else WriteLine("Khong tao duoc");

    }
    static void DropDataBase()
    {
      try
      {
        var dbContext = new ShopContext();
        string dbname = dbContext.Database.GetDbConnection().Database;
        var result = dbContext.Database.EnsureDeleted();
        if (result) WriteLine("Xoa thanh cong CSDL: " + dbname);
        else WriteLine("Khong tao duoc");
      }
      catch (System.Exception e)
      {
        WriteLine("Error : " + e);
        // throw;
      }
    }
    static async Task InsertData()
    {
      using var dbContext = new ShopContext();
      Category c1 = new Category("Điện thoại", "Các loại Điện thoại");
      Category c2 = new Category("Đồ uống", "Các loại đồ uống");
      await dbContext.categories.AddAsync(c1);
      await dbContext.categories.AddAsync(c2);
      WriteLine(c1?.CategoryId);
      if (c1 != null && c2 != null)
      {
        Product p1 = new Product() { Name = "Iphone 16", Price = 16m, CateId = 1 };
        Product p2 = new Product() { Name = "Huawei Pro", Price = 30m, Category = c1 };
        Product p3 = new Product() { Name = "Rượu Vang", Price = 3m, CateId = 2 };
        Product p4 = new Product() { Name = "Coca cola", Price = 1m, Category = c2 };
        await dbContext.AddAsync(p1);
        await dbContext.AddAsync(p2);
        await dbContext.AddAsync(p3);
        await dbContext.AddAsync(p4);
      }

      await dbContext.SaveChangesAsync();

    }
    public static async Task Main(string[] args)
    {
      OutputEncoding = Encoding.UTF8;
      // DropDataBase();
      // CreateDatabase();
      // await InsertData();

      // Linq
      var dbContext = new ShopContext();
      var product = (from p in dbContext.products where p.ProductId == 3 select p).FirstOrDefault();

      // reference to get data of another board data
      if (product != null)
      {
        var entry = dbContext.Entry(product);
        // used for reference

        // I use Lazyload, so no need to call this command
        // await entry.Reference(p => p.Category).LoadAsync();
        if (product.Category != null)
        {
          WriteLine($"\n{product.Category.Name} - {product.Category.Description}");
          WriteLine("\nCác sản phẩm thuộc loại 1 (loại " + product.Category.Name + ")");

          // Using Layzyload, we don't need to call these commands

          // var e = dbContext.Entry(product.Category);
          // // used for collection navigation
          // await e.Collection(c => c.Products).LoadAsync();

          WriteLine($"\nSố sản phẩm: {product?.Category?.Products?.Count()}");
          product?.Category?.Products?.ForEach(p => p.PrintInfo());
        }
      }

      WriteLine("\nSan pham voi ID = " + product?.ProductId);
      product?.PrintInfo();
      Write("\n");
    }
  }
}
```
