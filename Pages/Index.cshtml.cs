using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razorweb.Pages;
[Authorize]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myContext)
    {
        _logger = logger;
        myBlogContext = _myContext;
    }

    public void OnGet()
    {
        var pots = (from a in myBlogContext.articles
                    orderby a.Created descending
                    select a).ToList();
        ViewData["post"] = pots;
    }
}
