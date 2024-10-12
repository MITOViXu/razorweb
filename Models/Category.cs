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