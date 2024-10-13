using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43
{
  [Table("article")]
  public class Article
  {
    [Key]
    public int ArticleId { get; set; }
    [StringLength(100)]
    public string Title { get; set; }
  }
}