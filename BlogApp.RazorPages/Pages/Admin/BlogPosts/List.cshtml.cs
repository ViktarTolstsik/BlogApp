using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;

		public List<BlogPost> BlogPosts { get; set; }
        public ListModel(IBlogPostRepository BlogPostRepository)
        {
			blogPostRepository = BlogPostRepository;
		}
        public async Task OnGet()
        {
            var notificationJson = (string)TempData["MessageDescription"];
            if (notificationJson != null)
            {
                ViewData["MessageDescription"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
