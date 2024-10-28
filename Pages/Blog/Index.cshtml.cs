using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace razorweb.Pages_Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly MyBlogContext _context;
        public const int ITEM_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { set; get; }
        public int countPages { set; get; }

        public IndexModel(MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {

            // Calculate total number of articles and pages
            int totalArticle = await _context.articles.CountAsync();
            countPages = (int)Math.Ceiling((double)totalArticle / ITEM_PER_PAGE);

            // Initialize `currentPage` if it hasn't been set or is out of bounds
            if (currentPage < 1) currentPage = 1;
            if (currentPage > countPages) currentPage = countPages;

            // Apply pagination with validated `currentPage`
            var arrays = (from a in _context.articles
                          orderby a.Created descending
                          select a)
                          .Skip((currentPage - 1) * 10)
                          .Take(ITEM_PER_PAGE);

            // Filter articles by search string if provided
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = arrays.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else
            {
                Article = await arrays.ToListAsync();
            }
        }
    }
}
