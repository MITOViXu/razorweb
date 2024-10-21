public class ProductService
{
  private List<Product> products = new List<Product>();
  public ProductService()
  {
    LoadProducts();
  }
  public List<Product> AllProduct() => products;
  public void LoadProducts()
  {
    products.Clear();
    products.Add(new Product()
    {
      Id = 1,
      Name = "Huawei",
      Description = "Dien thoai Huawei",
      Price = 900
    });
    products.Add(new Product()
    {
      Id = 2,
      Name = "Sam sung",
      Description = "Dien thoai Sam sung",
      Price = 1000
    });
    products.Add(new Product()
    {
      Id = 3,
      Name = "Oppo",
      Description = "Dien thoai Oppo",
      Price = 1200
    });
  }
  public Product Find(int id)
  {
    return (from p in products
            where p.Id == id
            select p)
            .FirstOrDefault() ?? (new Product()
            {
              Id = 0,
              Name = "",
              Description = "Mat hang null",
              Price = 0
            });
  }
}