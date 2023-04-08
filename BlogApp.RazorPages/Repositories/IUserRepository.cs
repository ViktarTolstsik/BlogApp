using Microsoft.AspNetCore.Identity;

namespace BlogApp.RazorPages.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
