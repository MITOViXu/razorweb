using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43
{
  public class Tag
  {
    [Key]
    public int TagIdNew { get; set; }
    [Column(TypeName = "ntext")]
    public string Content { get; set; }
  }
}