using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorweb.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public CustomerInfo customerInfo { get; set; }
        private readonly ILogger<ContactModel> _logger;
        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Chon file Upload")]
        [DisplayName("File Upload")]
        public IFormFile FileUpload { get; set; }
        [BindProperty]
        [DataType(DataType.Upload)]
        // [FileExtensions(Extensions = "jpg,png,gif")]
        [Required(ErrorMessage = "Chon file Upload")]
        [DisplayName("Nhieu Files Upload")]

        public IFormFile[] FileUploads { get; set; }


        private readonly IWebHostEnvironment _webHostEnvironment;
        public ContactModel(ILogger<ContactModel> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            customerInfo = new CustomerInfo();
            Console.WriteLine("_Init contact");
        }
        public string thongbao { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                thongbao = "Dữ liệu gửi đến phù hợp";
                Console.WriteLine("Form is valid.");

                if (FileUpload != null)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", FileUpload.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                    FileUpload.CopyTo(fileStream);
                }
                foreach(var f in FileUploads){
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", f.FileName);
                    using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                    f.CopyTo(fileStream);
                }
            }
            else
            {
                thongbao = "Dữ liệu gửi đến KHÔNG phù hợp";
                Console.WriteLine("Form is invalid.");
            }
        }

    }
}
