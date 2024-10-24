using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserContact
{
  [BindProperty(SupportsGet = true)]
  [DisplayName("Id cua User")]
  [Range(10, 100, ErrorMessage = "Nhap sai")]
  public string UserID { get; set; }
  [BindProperty(SupportsGet = true)]
  [DisplayName("Email")]
  [EmailAddress(ErrorMessage = "Email sai dinh dang")]
  public string Email { get; set; }
  [BindProperty(SupportsGet = true)]
  [DisplayName("Ten nguoi dung")]
  public string UserName { get; set; }
}