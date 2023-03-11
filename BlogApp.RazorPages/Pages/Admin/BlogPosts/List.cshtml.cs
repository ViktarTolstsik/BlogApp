using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly BlogAppDbContext blogAppDbContext;

        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(BlogAppDbContext BlogAppDbContext)
        {
            blogAppDbContext = BlogAppDbContext;
        }
        public async Task OnGet()
        {
            BlogPosts = await blogAppDbContext.BlogPosts.ToListAsync();
        }
    }
}
