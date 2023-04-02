using BlogApp.RazorPages.Models.Domain;

namespace BlogApp.RazorPages.Repositories
{
	public interface IPostCommentRepository
	{
		Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
	}
}
