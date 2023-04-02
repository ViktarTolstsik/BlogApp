namespace BlogApp.RazorPages.Repositories
{
	public interface IPostLikeRepository
	{
		Task<int> GetTotalLikes(Guid blogPostId);
	}
}
