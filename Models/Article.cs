using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Article
{
  [Key]
  public int Id { get; set; }


  [StringLength(255, MinimumLength =5, ErrorMessage = "{0} phải dài từ {2} tới {1}")]
  [Required(ErrorMessage = "{0} phải nhập")]
  [Column(TypeName = "nvarchar")]
  [DisplayName("Tiêu đề")]
  
  public string Title { get; set; } 

  [DataType(DataType.Date)]
  [DisplayName("Ngày tạo")]
  [Required]
  public DateTime Created{ get; set; }

  [Column(TypeName = "ntext")]
  [DisplayName("Nội dung")]
  public string Content { get; set; } 
}