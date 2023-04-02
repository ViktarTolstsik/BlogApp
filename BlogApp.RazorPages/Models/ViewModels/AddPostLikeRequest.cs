namespace BlogApp.RazorPages.Models.ViewModels
{
	public class AddPostLikeRequest
	{
		public Guid PostId { get; set; }
		public Guid UserId { get; set; }
	}
}
