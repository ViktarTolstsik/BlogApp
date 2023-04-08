using Microsoft.AspNetCore.Identity;

namespace BlogApp.RazorPages.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
        Task<bool> Add(IdentityUser user, string password, List<string> roles);
        Task Delete(Guid userId);
    }
}
