using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.RazorPages.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var superAdminRoleId = "eb75475b-ae2a-4076-98e3-a9bd90ba3f90";
			var adminRoleId = "6ac4033f-d0a4-40fa-abce-1ecbb85230d4";
			var userRoleId = "6fba2a38-5a33-406c-a8e6-06dc54383f85";

			//Seed Roles (User, Admin, Super Admin)
			var roles = new List<IdentityRole>
			{
				new IdentityRole()
				{
					Name= "SuperAdmin",
					NormalizedName = "SuperAdmin",
					Id = superAdminRoleId,
					ConcurrencyStamp = superAdminRoleId
				},
				new IdentityRole()
				{
					Name= "Admin",
					NormalizedName = "Admin",
					Id = adminRoleId,
					ConcurrencyStamp = adminRoleId
				},
				new IdentityRole()
				{
					Name= "User",
					NormalizedName = "User",
					Id = userRoleId,
					ConcurrencyStamp = userRoleId
				}
			};

			builder.Entity<IdentityRole>().HasData(roles);

			//Seed Super Admin User
			var superAdminId = "55af30d8-faaf-425a-b153-1adad490dd46";
			var superAdminUser = new IdentityUser()
			{
				Id = superAdminId,
				UserName = "superadmin@blogapp.com",
				Email = "superadmin@blogapp.com",
				NormalizedEmail = "superadmin@blogapp.com".ToUpper(),
				NormalizedUserName = "superadmin@blogapp.com".ToUpper()
			};

			superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin123");

			builder.Entity<IdentityUser>().HasData(superAdminUser);

			//Add all roles to Super Admin user 
			var superAdminRoles = new List<IdentityUserRole<string>>
			{
				new IdentityUserRole<string>
				{
					RoleId = superAdminRoleId,
					UserId = superAdminId
				},
				new IdentityUserRole<string>
				{
					RoleId = adminRoleId,
					UserId = superAdminId
				},
				new IdentityUserRole<string>
				{
					RoleId = userRoleId,
					UserId = superAdminId
				}
			};

			builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
		}
	}
}
