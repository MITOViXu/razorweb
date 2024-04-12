using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cs58.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext myBlogContext;
    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myContext)
    {
        myBlogContext = _myContext;
        _logger = logger;
    }

    public void OnGet()
    {
        var post = (from a in myBlogContext.articles
                    orderby a.Created descending
                    select a).ToList();
        ViewData["post"] = post;
    }
}
