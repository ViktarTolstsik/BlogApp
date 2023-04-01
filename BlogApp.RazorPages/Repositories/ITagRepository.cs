using BlogApp.RazorPages.Models.Domain;

namespace BlogApp.RazorPages.Repositories
{
	public interface ITagRepository
	{
		Task<IEnumerable<Tag>> GetAllTagsAsync();
	}
}
