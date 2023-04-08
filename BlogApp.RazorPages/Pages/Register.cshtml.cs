using BlogApp.RazorPages.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApp.RazorPages.Pages
{
    public class RegisterModel : PageModel
    {
		private readonly UserManager<IdentityUser> userManager;

		[BindProperty]
        public Register RegisterVM { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
			this.userManager = userManager;
		}
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {


                var user = new IdentityUser
                {
                    UserName = RegisterVM.Username,
                    Email = RegisterVM.Email
                };

                var identityResult = await userManager.CreateAsync(user, RegisterVM.Password);

                if (identityResult.Succeeded)
                {
                    var addRolesResult = await userManager.AddToRoleAsync(user, "User");

                    if (addRolesResult.Succeeded)
                    {
                        ViewData["MessageDescription"] = new Notification
                        {
                            Type = Enums.NotificationType.Success,
                            Message = "Registration successful."
                        };
                        return Page();
                    }
                }
                else
                {
                    ViewData["MessageDescription"] = new Notification
                    {
                        Type = Enums.NotificationType.Error,
                        Message = "Registration failed."
                    };
                }
                return Page();
            }
            else
            {
                return Page();
            }

        }
    }
}
