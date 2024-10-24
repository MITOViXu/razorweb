# Validation, ModelBinder and UploadFile 🎍🎪🎢🎭🧶

## Create your own Validation

```cs
[Display(Name = "Năm sinh")]
[Required]
[SoChan]
public int? YearOfBirth { get; set; }
```

**SoChan.cs**

```cs
using System.ComponentModel.DataAnnotations;

public class SoChan : ValidationAttribute
{
  public SoChan() => ErrorMessage = "{0} phai la so chan";
  public override bool IsValid(object value)
  {
    if (value == null) return false;
    int i = int.Parse(value.ToString());
    return i % 2 == 0;
  }
}
```

## Create your own Binder property

```cs
  [Display(Name = "Tên khách hàng")]
  [Required(ErrorMessage = "Phai nhap {0}")]
  [ModelBinder(BinderType = typeof(UserNameBinding))]

  // Working the same way
  // [DisplayName("Tên khách hàng")]
  public string CustomerName { get; set; }
```

**UserNameBind.cs**

```cs
using Microsoft.AspNetCore.Mvc.ModelBinding;

/**
  -
*/
public class UserNameBinding : IModelBinder
{
  public Task BindModelAsync(ModelBindingContext bindingContext)
  {
    if (bindingContext == null)
    {
      throw new ArgumentException("bindingContext");
    }
    string modelName = bindingContext.ModelName;

    var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
    if (valueProviderResult == ValueProviderResult.None) return Task.CompletedTask;
    string value = valueProviderResult.FirstValue;
    if (string.IsNullOrEmpty(value)) return Task.CompletedTask;
    //
    string s = value.ToUpper();
    if (s.Contains("XXX"))
    {
      bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
      bindingContext.ModelState.TryAddModelError(modelName, "Lỗi do chứa XXX");
      return Task.CompletedTask;
    }
    s = s.Trim();
    bindingContext.ModelState.SetModelValue(modelName, s, s);
    bindingContext.Result = ModelBindingResult.Success(s);

    return Task.CompletedTask;

  }
}
```

## File Upload

```cs
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

```
