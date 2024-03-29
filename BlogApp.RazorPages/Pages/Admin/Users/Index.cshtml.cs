using BlogApp.RazorPages.Models.ViewModels;
using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages.Admin.Users
{
	[Authorize(Roles ="Admin")]
	public class IndexModel : PageModel
	{
		private readonly IUserRepository userRepository;

		public List<User> Users { get; set; }
		[BindProperty]
		public AddUser AddUserRequest { get; set; }
		[BindProperty]
		public Guid SelectedUserId { get; set; }
		public IndexModel(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}
		public async Task<IActionResult> OnGet()
		{
			var users = await userRepository.GetAll();

			Users = new List<User>();
			foreach (var user in users)
			{
				Users.Add(new User
				{
					Id = Guid.Parse(user.Id),
					UserName = user.UserName,
					Email = user.Email,
				});
			}

			return Page();
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var identityUser = new IdentityUser
				{
					UserName = AddUserRequest.UserName,
					Email = AddUserRequest.Email,
				};

				var roles = new List<string> { "User" };

				if (AddUserRequest.AdminCheckbox)
				{
					roles.Add("Admin");
				}
				var result = await userRepository.Add(identityUser, AddUserRequest.Password, roles);

				if (result)
				{
					return RedirectToPage("/admin/users/index");
				}
				return Page();
			}
			else
			{
				return Page();
			}

		}
		public async Task<IActionResult> OnPostDelete()
		{
			await userRepository.Delete(SelectedUserId);

			return RedirectToPage("/admin/users/index");
		}
	}
}
