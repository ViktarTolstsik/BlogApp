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

        public void OnGet(Guid Id)
        {
            BlogPost = blogAppDbContext.BlogPosts.Find(Id);
        }
        public IActionResult OnPost()
        {
            var existingBlogPost = blogAppDbContext.BlogPosts.Find(BlogPost.Id);

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

            blogAppDbContext.SaveChanges();
            return RedirectToPage("/admin/blogposts/list");
        }
    }
}
