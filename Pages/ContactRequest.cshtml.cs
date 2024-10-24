using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Console;
namespace razorweb.Pages
{
    public class ContactRequestModel : PageModel
    {
        // Default is post
        [BindProperty]
        public UserContact userContact { get; set; }
        private readonly ILogger<ContactRequestModel> _logger;
        public ContactRequestModel(ILogger<ContactRequestModel> logger)
        {
            _logger = logger;
            userContact = new UserContact();
            WriteLine("Init Contact...");
        }
        public int Tong(int a, int b)
        {
            return a + b;
        }
    }
}
