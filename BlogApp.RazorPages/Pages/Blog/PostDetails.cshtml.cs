using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Blog
{
    public class PostDetailsModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;
		private readonly IPostLikeRepository postLikeRepository;

		public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }
        public PostDetailsModel(IBlogPostRepository blogPostRepository, IPostLikeRepository postLikeRepository)
        {
			this.blogPostRepository = blogPostRepository;
			this.postLikeRepository = postLikeRepository;
		}
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetPostAsync(urlHandle);

            if(BlogPost != null) 
            {
               TotalLikes = await postLikeRepository.GetTotalLikes(BlogPost.Id);
            }
            return Page();
        }
    }
}
