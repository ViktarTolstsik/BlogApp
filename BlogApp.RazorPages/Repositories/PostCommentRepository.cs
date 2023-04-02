using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Repositories
{
	public class PostCommentRepository : IPostCommentRepository
	{
		private readonly BlogAppDbContext blogAppDbContext;

		public PostCommentRepository(BlogAppDbContext blogAppDbContext)
		{
			this.blogAppDbContext = blogAppDbContext;
		}
		public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
		{
			await blogAppDbContext.BlogPostComment.AddAsync(blogPostComment);
			await blogAppDbContext.SaveChangesAsync();
			return blogPostComment;
		}

		public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId)
		{
			return await blogAppDbContext.BlogPostComment.Where(x => x.PostId == blogPostId).ToListAsync();
		}
	}
}
