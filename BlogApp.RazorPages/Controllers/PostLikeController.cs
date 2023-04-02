using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.RazorPages.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PostLikeController : Controller
	{
		private readonly IPostLikeRepository postLikeRepository;

		public PostLikeController(IPostLikeRepository postLikeRepository)
		{
			this.postLikeRepository = postLikeRepository;
		}
		[Route("Add")]
		public async Task<IActionResult> AddLike([FromBody] AddPostLikeRequest addPostLikeRequest)
		{
			await postLikeRepository.AddLike(addPostLikeRequest.PostId, addPostLikeRequest.UserId);

			return Ok();
		}
	}
}
