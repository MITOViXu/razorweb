using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorweb.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public CustomerInfo customerInfo { get; set; }
        private readonly ILogger<ContactModel> _logger;
        public ContactModel(ILogger<ContactModel> logger){
            _logger = logger;
            Console.WriteLine("_Init contact");
        }
    }
}
