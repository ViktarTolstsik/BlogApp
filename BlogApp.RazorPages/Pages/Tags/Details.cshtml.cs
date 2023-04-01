using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Tags
{
    public class DetailsModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;
        public List<BlogPost> Blogs { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
			this.blogPostRepository = blogPostRepository;
		}
        public async Task<IActionResult> OnGet(string tagName)
        {
           Blogs = (await blogPostRepository.GetAllAsync(tagName)).ToList();
           return Page();
        }
    }
}
