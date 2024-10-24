using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class CustomerInfo
{
  [Display(Name = "Tên khách hàng")]
  // Working the same way 
  // [DisplayName("Tên khách hàng")]
  public string CustomerName { get; set; }
  [Display(Name = "Địa chỉ Email")]
  public string Email { get; set; }
  [Display(Name = "Năm sinh")]
  public int? YearOfBirth { get; set; }

}