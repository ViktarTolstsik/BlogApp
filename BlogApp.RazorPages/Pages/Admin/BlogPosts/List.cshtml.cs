using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
