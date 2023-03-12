using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;

		[BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public AddModel(IBlogPostRepository BlogPostRepository)
        {
			this.blogPostRepository = BlogPostRepository;
		}
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };

            await blogPostRepository.AddPostAsync(blogPost);

            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "New blog post created!"
            };

            //TempData can't transfer complex objects =(
            TempData["MessageDescription"] = JsonSerializer.Serialize(notification);

			return RedirectToPage("/admin/blogposts/list");
        }
    }
}
