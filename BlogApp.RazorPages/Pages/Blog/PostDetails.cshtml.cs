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
		private readonly IPostCommentRepository postCommentRepository;

		public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; }
        public bool IsLiked { get; set; }
        
        [BindProperty]
        public Guid BlogPostId { get; set; }

        [BindProperty]
        public string CommentDescription { get; set; }

        public PostDetailsModel(IBlogPostRepository blogPostRepository, 
            IPostLikeRepository postLikeRepository, 
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            IPostCommentRepository postCommentRepository)
        {
			this.blogPostRepository = blogPostRepository;
			this.postLikeRepository = postLikeRepository;
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.postCommentRepository = postCommentRepository;
		}
        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await blogPostRepository.GetPostAsync(urlHandle);

            if(BlogPost != null) 
            {
                BlogPostId = BlogPost.Id;

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

        public async Task<IActionResult> OnPost(string urlHandle)
        {
            if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
            {
                var comment = new BlogPostComment()
                {
                    PostId = BlogPostId,
                    Description = CommentDescription,
                    AddedDate = DateTime.Now,
                    UserId = Guid.Parse(userManager.GetUserId(User))
                };

                await postCommentRepository.AddAsync(comment);

			}
            return RedirectToPage("/blog/postdetails", new { urlHandle = urlHandle });
        }
    }
}
