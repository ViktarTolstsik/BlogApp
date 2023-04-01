using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;

		[BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }
        public EditModel(IBlogPostRepository BlogPostRepository)
        {
			blogPostRepository = BlogPostRepository;
		}

        public async Task OnGet(Guid Id)
        {
            BlogPost = await blogPostRepository.GetPostAsync(Id);

            if (BlogPost.Tags != null  && BlogPost != null) 
            {
                Tags = string.Join(",", BlogPost.Tags.Select(x => x.Name));
            }
        }
        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                BlogPost.Tags = new List<Tag> (Tags.Split(',').Select(x => new Tag() { Name = x.Trim()}));

                await blogPostRepository.UpdatePostAsync(BlogPost);

                ViewData["MessageDescription"] = new Notification
                {
                    Message = "Update was successful!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception ex)
            {
				ViewData["MessageDescription"] = new Notification
				{
					Message = ex.Message,
					Type = Enums.NotificationType.Error
				};
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDelete() 
        {
            var deleted = await blogPostRepository.DeletePostAsync(BlogPost.Id);
            if (deleted)
            {
				var notification = new Notification
				{
					Type = Enums.NotificationType.Success,
					Message = "Blog post deleted successfully!"
				};

				//TempData can't transfer complex objects =(
				TempData["MessageDescription"] = JsonSerializer.Serialize(notification);

				return RedirectToPage("/admin/blogposts/list");
            }

            return Page();
        }
    }
}
