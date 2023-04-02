using BlogApp.RazorPages.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Repositories
{
	public class PostLikeRepository : IPostLikeRepository
	{
		private readonly BlogAppDbContext blogAppDbContext;

		public PostLikeRepository(BlogAppDbContext blogAppDbContext)
		{
			this.blogAppDbContext = blogAppDbContext;
		}
		public async Task<int> GetTotalLikes(Guid blogPostId)
		{
			return await blogAppDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
		}
	}
}
