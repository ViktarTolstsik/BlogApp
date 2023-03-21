using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Blog
{
    public class PostDetailsModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;
        public BlogPost BlogPost { get; set; }

        public PostDetailsModel(IBlogPostRepository blogPostRepository)
        {
			this.blogPostRepository = blogPostRepository;
		}
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetPostAsync(urlHandle);
            return Page();
        }
    }
}
