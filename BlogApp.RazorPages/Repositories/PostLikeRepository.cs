using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
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

		public async Task AddLike(Guid postId, Guid userId)
		{
			var like = new BlogPostLike
			{
				Id = Guid.NewGuid(),
				BlogPostId = postId,
				UserId = userId
			};

			await blogAppDbContext.BlogPostLike.AddAsync(like);
			await blogAppDbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<BlogPostLike>> GetLikes(Guid postId)
		{
			return await blogAppDbContext.BlogPostLike.Where(x => x.BlogPostId == postId).ToListAsync();
		}

		public async Task<int> GetTotalLikes(Guid blogPostId)
		{
			return await blogAppDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
		}
	}
}
