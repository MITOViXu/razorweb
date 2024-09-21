namespace Sanpham
{
  public partial class Product
  {
    public string name { get; set; }
    public decimal price { get; set; }
    public string GetInfor()
    {
      return @$"{name} / {price} : {this.description} : NSX {this.manuFactory.name}";
    }
  }
}