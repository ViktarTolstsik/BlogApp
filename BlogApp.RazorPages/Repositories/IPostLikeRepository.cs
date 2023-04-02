namespace BlogApp.RazorPages.Repositories
{
	public interface IPostLikeRepository
	{
		Task<int> GetTotalLikes(Guid blogPostId);
		Task AddLike(Guid postId, Guid userId);
	}
}
