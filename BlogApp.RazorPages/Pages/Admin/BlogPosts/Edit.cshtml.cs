using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;

		[BindProperty]
        public BlogPost BlogPost { get; set; }

		public EditModel(IBlogPostRepository BlogPostRepository)
        {
			blogPostRepository = BlogPostRepository;
		}

        public async Task OnGet(Guid Id)
        {
            BlogPost = await blogPostRepository.GetPostAsync(Id);
        }
        public async Task<IActionResult> OnPostEdit()
        {
            await blogPostRepository.UpdatePostAsync(BlogPost);

            ViewData["MessageDescription"] = "Update successfull!";

            return Page();
        }
        public async Task<IActionResult> OnPostDelete() 
        {
            var deleted = await blogPostRepository.DeletePostAsync(BlogPost.Id);
            if (deleted)
            {
                return RedirectToPage("/admin/blogposts/list");
            }

            return Page();
        }
    }
}
