using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorweb.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;
        public readonly ProductService _productService;

        public Product product { get; set; }
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                ViewData["Title"] = $"Sản phẩm có id = {id.Value}";
                product = _productService.Find(id.Value);
            }
            else
            {
                ViewData["Title"] = $"Danh sách sản phẩm";
            }
        }
        // /product/{id:int?}?handler=lastproduct
        public void OnGetLastProduct()
        {
            ViewData["Title"]= "Sản phẩm cuối";
             product = _productService.AllProduct().LastOrDefault() ?? (new Product()
            {
                Id = 0,
                Name = "",
                Description = "Mat hang null",
                Price = 0
            });

        }
    }
}
