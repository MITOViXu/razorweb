namespace Sanpham
{
  // merging 2 definition of namespace Sampham with "partial" key word
  public partial class Product
  {
    public ManuFactory manuFactory { set; get; }
    public class ManuFactory()
    {
      public string name { set; get; }
      public string addr { set; get; }
    }
    public string description { set; get; }
    public void Abc()
    {

    }
  }
}