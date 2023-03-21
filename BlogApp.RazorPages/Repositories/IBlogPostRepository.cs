using BlogApp.RazorPages.Models.Domain;

namespace BlogApp.RazorPages.Repositories
{
	public interface IBlogPostRepository
	{
		Task<IEnumerable<BlogPost>> GetAllAsync();
		Task<BlogPost> GetPostAsync(Guid id);
		Task<BlogPost> GetPostAsync(string urlHandle);
		Task<BlogPost> AddPostAsync(BlogPost blogPost);
		Task<BlogPost> UpdatePostAsync(BlogPost blogPost);
		Task<bool> DeletePostAsync(Guid id);
	}
}
