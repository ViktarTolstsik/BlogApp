using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Repositories
{
	public class BlogPostRepository : IBlogPostRepository
	{
		private readonly BlogAppDbContext blogAppDbContext;

		public BlogPostRepository(BlogAppDbContext BlogAppDbContext)
		{
			blogAppDbContext = BlogAppDbContext;
		}
		public async Task<BlogPost> AddPostAsync(BlogPost blogPost)
		{
			await blogAppDbContext.BlogPosts.AddAsync(blogPost);
			await blogAppDbContext.SaveChangesAsync();
			return blogPost;
		}

		public async Task<bool> DeletePostAsync(Guid Id)
		{
			var existingBlogPost = await blogAppDbContext.BlogPosts.FindAsync(Id);
			if (existingBlogPost != null) 
			{
				blogAppDbContext.BlogPosts.Remove(existingBlogPost);
				await blogAppDbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<BlogPost>> GetAllAsync()
		{
			return await blogAppDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).ToListAsync();

		}

		public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
		{
			return await (blogAppDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).Where(x => x.Tags.Any(x => x.Name == tagName))).ToListAsync();
		}

		public async Task<BlogPost> GetPostAsync(Guid Id)
		{
			return await blogAppDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.Id == Id);
		}

		public async Task<BlogPost> GetPostAsync(string urlHandle)
		{
			return await blogAppDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
		}

		public async Task<BlogPost> UpdatePostAsync(BlogPost blogPost)
		{
			var existingBlogPost = await blogAppDbContext.BlogPosts.Include(nameof(blogPost.Tags)).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

			if (existingBlogPost != null)
			{
				existingBlogPost.Heading = blogPost.Heading;
				existingBlogPost.PageTitle = blogPost.PageTitle;
				existingBlogPost.Content = blogPost.Content;
				existingBlogPost.ShortDescription = blogPost.ShortDescription;
				existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
				existingBlogPost.UrlHandle = blogPost.UrlHandle;
				existingBlogPost.PublishedDate = blogPost.PublishedDate;
				existingBlogPost.Author = blogPost.Author;
				existingBlogPost.Visible = blogPost.Visible;


				if (blogPost.Tags != null && blogPost.Tags.Any())
				{
					//Delete the existing tags
					blogAppDbContext.Tags.RemoveRange(existingBlogPost.Tags);

					//Add new tags
					blogPost.Tags.ToList().ForEach(x => x.BlogPostId = existingBlogPost.Id);
					await blogAppDbContext.Tags.AddRangeAsync(blogPost.Tags);
				}

			}

			await blogAppDbContext.SaveChangesAsync();
			return blogPost;
		}
	}
}
