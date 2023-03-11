using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
		private readonly BlogAppDbContext blogAppDbContext;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

		public EditModel(BlogAppDbContext BlogAppDbContext)
        {
			blogAppDbContext = BlogAppDbContext;
		}

        public async Task OnGet(Guid Id)
        {
            BlogPost = await blogAppDbContext.BlogPosts.FindAsync(Id);
        }
        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await blogAppDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null) 
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle= BlogPost.PageTitle;
                existingBlogPost.Content= BlogPost.Content;
                existingBlogPost.ShortDescription= BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl= BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle= BlogPost.UrlHandle;
                existingBlogPost.PublishedDate= BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible= BlogPost.Visible;
            }

            await blogAppDbContext.SaveChangesAsync();
            return RedirectToPage("/admin/blogposts/list");
        }
        public async Task<IActionResult> OnPostDelete() 
        {
            var existingBlogPost = await blogAppDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null) 
            {
                blogAppDbContext.BlogPosts.Remove(existingBlogPost);
                await blogAppDbContext.SaveChangesAsync();

                return RedirectToPage("/admin/blogposts/list");
            }
            return Page();
        }
    }
}
