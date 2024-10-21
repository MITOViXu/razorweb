using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorweb.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    public readonly ProductService _productService;

    public PrivacyModel(ILogger<PrivacyModel> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }
    public Product product { get; set; }
    public void OnGet()
    {
        
    }
}

