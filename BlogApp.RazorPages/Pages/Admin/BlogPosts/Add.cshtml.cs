using BlogApp.RazorPages.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            var heading = Request.Form["heading"];
        }
    }
}
