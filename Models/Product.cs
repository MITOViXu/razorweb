using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Console;
namespace ef
{
  // [Table("Product")]
  public class Product
  {
    // [Key]
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


    public int? CateId2 { set; get; }
    public virtual Category? Category2 { set; get; }

    public void PrintInfo()
    {
      WriteLine("\nID: " + ProductId + ", Name: " + Name + ", Price: " + Price + ", CateID: " + CateId);
    }
  }
}