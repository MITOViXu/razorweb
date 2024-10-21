using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Console;
public class ContactRequestModel : PageModel
{
  public string UserId { get; set; } = "\nXuan thu lab...\n";
  private readonly ILogger<ContactRequestModel> _logger;
  public ContactRequestModel(ILogger<ContactRequestModel> logger)
  {
    _logger = logger;
    WriteLine("Init Contact...");
  }
  public int Tong(int a, int b)
  {
    return a + b;
  }
}