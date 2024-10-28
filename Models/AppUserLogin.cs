using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class AppUserLogin : IdentityUserLogin<string>
{
  [Column(TypeName = "nvarchar(100)")]
  public string Password { get; set; }
}