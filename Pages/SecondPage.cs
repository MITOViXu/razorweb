using Microsoft.AspNetCore.Mvc.RazorPages;

public class SecondPage : PageModel{
  public void OnGet(){
    ViewData["data2"] = "Đã call đến PageModel";
  }
}