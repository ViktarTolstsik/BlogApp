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
		[HttpPost]
		public async Task<IActionResult> AddLike([FromBody] AddPostLikeRequest addPostLikeRequest)
		{
			await postLikeRepository.AddLike(addPostLikeRequest.PostId, addPostLikeRequest.UserId);

			return Ok();
		}

		[Route("{postId:Guid}/totalLikes")]
		[HttpGet]
		public async Task<IActionResult> GetLikes([FromRoute] Guid postId)
		{
			var likes = await postLikeRepository.GetTotalLikes(postId);

			return Ok(likes);
		}
	}
}
