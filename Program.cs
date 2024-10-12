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