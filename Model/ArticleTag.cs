using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43
{
  public class ArticleTag
  {
    [Key]
    public int ArticleTagId { get; set; }

    public int TagId { get; set; } // FK
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }

    public int ArticleId { get; set; } // FK
    [ForeignKey("ArticleId")]
    public Article Article { get; set; }
  }
}