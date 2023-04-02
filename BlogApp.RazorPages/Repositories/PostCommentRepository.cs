using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;

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
	}
}
