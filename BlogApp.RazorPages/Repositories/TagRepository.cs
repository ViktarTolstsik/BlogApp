using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Repositories
{
	public class TagRepository : ITagRepository
	{
		private readonly BlogAppDbContext blogAppDbContext;

		public TagRepository(BlogAppDbContext blogAppDbContext)
		{
			this.blogAppDbContext = blogAppDbContext;
		}
		public async Task<IEnumerable<Tag>> GetAllTagsAsync()
		{
			var tags = await blogAppDbContext.Tags.ToListAsync();

			tags.DistinctBy(x => x.Name.ToLower());

			return tags;
		}
	}
}
