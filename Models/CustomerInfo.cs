using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
  [Display(Name = "Tên khách hàng")]
  [Required(ErrorMessage = "Phai nhap {0}")]
  [ModelBinder(BinderType = typeof(UserNameBinding))]

  // Working the same way 
  // [DisplayName("Tên khách hàng")]
  public string CustomerName { get; set; }



  [Display(Name = "Địa chỉ Email")]
  [EmailAddress]
  [Required]
  public string Email { get; set; }
  [Display(Name = "Năm sinh")]
  [Required]
  [SoChan]
  public int? YearOfBirth { get; set; }

}