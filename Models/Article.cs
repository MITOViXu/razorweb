using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// [Table("posts")]
public class Article
{
  [Key]
  public int Id { get; set; }
  [StringLength(255)]
  [Required]
  [DisplayName("Tiêu đề")]
  [Column(TypeName = "nvarchar")]
  public string Title { get; set; }
  [DataType(DataType.Date)]
  [Required]
  [DisplayName("Ngày tạo")]
  public DateTime Created { get; set; }
  [Column(TypeName = "ntext")]
  [DisplayName("Nội dung")]
  public string Content { get; set; }

}