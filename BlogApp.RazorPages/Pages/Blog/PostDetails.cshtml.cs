using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Blog
{
    public class PostDetailsModel : PageModel
    {
		private readonly IBlogPostRepository blogPostRepository;
		private readonly IPostLikeRepository postLikeRepository;
		private readonly SignInManager<IdentityUser> signInManager;
		private readonly UserManager<IdentityUser> userManager;

		public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }
        public bool IsLiked { get; set; }
        public PostDetailsModel(IBlogPostRepository blogPostRepository, IPostLikeRepository postLikeRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
			this.blogPostRepository = blogPostRepository;
			this.postLikeRepository = postLikeRepository;
			this.signInManager = signInManager;
			this.userManager = userManager;
		}
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetPostAsync(urlHandle);

            if(BlogPost != null) 
            {
                if (signInManager.IsSignedIn(User))
                {
                    var likes = await postLikeRepository.GetLikes(BlogPost.Id);

                    var userId = userManager.GetUserId(User);

                    IsLiked = likes.Any(x => x.UserId == Guid.Parse(userId));
                }

               TotalLikes = await postLikeRepository.GetTotalLikes(BlogPost.Id);
            }
            return Page();
        }
    }
}
