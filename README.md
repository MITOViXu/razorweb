# Entity Framework Basic 🎄🎋🎆🧨🎉🎃

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

## Model

Product.cs

```cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
  [Table("product")]
  public class Product
  {
    [Key]
    public int ProductId { get; set; }
    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }
    [StringLength(50)]
    public string Provider { get; set; }
    public Product(string ProductName, string Provider)
    {
      this.ProductName = ProductName;
      this.Provider = Provider;
    }
    public void Info()
    {
      Console.WriteLine(ProductId + " - " + ProductName + " - " + Provider);
    }

  }
}
```

ProductDbContext.cs

```cs
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
```

Program.cs

```cs
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using ef;
using Microsoft.EntityFrameworkCore;
using static System.Console;
namespace CS40
{
  public class Program
  {
    static void CreateDataBase()
    {
      try
      {
        var dbContext = new ProductDbContext();
        string dbname = dbContext.Database.GetDbConnection().Database;
        var result = dbContext.Database.EnsureCreated();
        if (result) WriteLine("Khoi tao thanh cong CSDL: " + dbname);
        else WriteLine("Khong tao duoc");
      }
      catch (System.Exception e)
      {
        WriteLine("Error : " + e);
        // throw;
      }
    }
    static void DropDataBase()
    {
      try
      {
        var dbContext = new ProductDbContext();
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
    static async void Insert()
    {
      using var dbContext = new ProductDbContext();
      /*
        - Model (Product)
        - Add, AddAsync
        - SaveChange
      */

      // Add independent element
      // var p1 = new Product();
      // p1.ProductName = "San pham 1";
      // p1.Provider = "Cong ty 1";
      // await dbContext.AddAsync(p1);
      // var sodong = dbContext.SaveChanges();

      // Add an array of products
      var p1 = new Product[]{
        new Product("San pham 2","Cong ty 2"),
        new Product("San pham 3","Cong ty 3"),
        new Product("San pham 4","Cong ty 4")
      };

      await dbContext.AddRangeAsync(p1);
      var sodong = dbContext.SaveChanges();
      WriteLine("So dong da insert: " + sodong);
    }
    static void ReadProducts()
    {
      var dbContext = new ProductDbContext();

      // Linq
      // var products = dbContext.products.ToList();
      // products.ForEach(p => { p.Info(); });
      var qr = from prod in dbContext.products
               where prod.ProductId >= 1 && prod.Provider.Contains("ong")
               orderby prod.ProductId descending
               select prod;
      Write("\nCác sản phẩm có ID lớn hơn 1\n");
      qr.ToList().ForEach(x => x.Info());

      var qr2 = (from prod in dbContext.products
                 where prod.ProductId >= 1 && prod.Provider.Contains("ong")
                 orderby prod.ProductId descending
                 select prod).FirstOrDefault();
      Write("\n \nMột sản phẩm duy nhất: ");
      qr2?.Info();
    }
    static void Rename(string name, int id)
    {
      using var dbContext = new ProductDbContext();
      var pro = (from p in dbContext.products
                 where p.ProductId == id
                 select p).FirstOrDefault();
      pro?.Info();
      if (pro != null) pro.ProductName = name;
      WriteLine("Đã cập nhật " + dbContext.SaveChanges() + " dòng");
    }
    public static void Main(string[] args)
    {
      OutputEncoding = Encoding.UTF8;
      // Entity -> Database, Table
      // Database - SQL Server : data01 -> DnContext
      // --product

      // DropDataBase();
      // CreateDataBase();
      // Insert();
      // ReadProducts();
      // Rename("Sản phẩm 1", 1);
      // Rename("Sản phẩm 2", 2);
      // Rename("Sản phẩm 3", 3);
      // Rename("Sản phẩm 4", 4);
      ReadProducts();
      
      // Logging -
      WriteLine();
      WriteLine();
    }
  }
}
```
