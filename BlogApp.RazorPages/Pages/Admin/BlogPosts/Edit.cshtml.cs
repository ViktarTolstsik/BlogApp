using BlogApp.RazorPages.Data;
using BlogApp.RazorPages.Models.Domain;
using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BlogApp.RazorPages.Pages.Admin.BlogPosts
{
	[Authorize(Roles = "Admin")]
	public class EditModel : PageModel
	{
		private readonly IBlogPostRepository blogPostRepository;

		[BindProperty]
		public EditPostRequest BlogPost { get; set; }

		//[BindProperty]
		//public IFormFile FeaturedImage { get; set; }

		[BindProperty]
		[Required]
		public string Tags { get; set; }
		public EditModel(IBlogPostRepository BlogPostRepository)
		{
			blogPostRepository = BlogPostRepository;
		}

		public async Task OnGet(Guid Id)
		{
			var blogPostDomainModel = await blogPostRepository.GetPostAsync(Id);

			if (blogPostDomainModel != null && blogPostDomainModel.Tags != null)
			{
				BlogPost = new EditPostRequest
				{
					Id = blogPostDomainModel.Id,
					Heading = blogPostDomainModel.Heading,
					PageTitle = blogPostDomainModel.PageTitle,
					Content = blogPostDomainModel.Content,
					ShortDescription = blogPostDomainModel.ShortDescription,
					FeaturedImageUrl = blogPostDomainModel.FeaturedImageUrl,
					UrlHandle = blogPostDomainModel.UrlHandle,
					PublishedDate = blogPostDomainModel.PublishedDate,
					Author = blogPostDomainModel.Author,
					Visible = blogPostDomainModel.Visible
				};

				Tags = string.Join(",", blogPostDomainModel.Tags.Select(x => x.Name));
			}
		}
		public async Task<IActionResult> OnPostEdit()
		{
			if (ModelState.IsValid)
			{
				try
				{
					var blogPostDomainModel = new BlogPost
					{
						Id = BlogPost.Id,
						PageTitle = BlogPost.PageTitle,
						Heading = BlogPost.Heading,
						Content = BlogPost.Content,
						ShortDescription = BlogPost.ShortDescription,
						FeaturedImageUrl = BlogPost.FeaturedImageUrl,
						UrlHandle = BlogPost.UrlHandle,
						PublishedDate = BlogPost.PublishedDate,
						Author = BlogPost.Author,
						Visible = BlogPost.Visible,
						Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
					};


					await blogPostRepository.UpdatePostAsync(blogPostDomainModel);

					ViewData["MessageDescription"] = new Notification
					{
						Message = "Update was successful!",
						Type = Enums.NotificationType.Success
					};
				}
				catch (Exception ex)
				{
					ViewData["MessageDescription"] = new Notification
					{
						Message = ex.Message,
						Type = Enums.NotificationType.Error
					};
				}

				return Page();
			}

			return Page();
		}
		public async Task<IActionResult> OnPostDelete()
		{
			var deleted = await blogPostRepository.DeletePostAsync(BlogPost.Id);
			if (deleted)
			{
				var notification = new Notification
				{
					Type = Enums.NotificationType.Success,
					Message = "Blog post deleted successfully!"
				};

				//TempData can't transfer complex objects =(
				TempData["MessageDescription"] = JsonSerializer.Serialize(notification);

				return RedirectToPage("/admin/blogposts/list");
			}

			return Page();
		}
	}
}
