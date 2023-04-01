using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApp.RazorPages.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Removingsuperadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ac4033f-d0a4-40fa-abce-1ecbb85230d4", "55af30d8-faaf-425a-b153-1adad490dd46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6fba2a38-5a33-406c-a8e6-06dc54383f85", "55af30d8-faaf-425a-b153-1adad490dd46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb75475b-ae2a-4076-98e3-a9bd90ba3f90", "55af30d8-faaf-425a-b153-1adad490dd46" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55af30d8-faaf-425a-b153-1adad490dd46");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55af30d8-faaf-425a-b153-1adad490dd46", 0, "2958dc09-9385-4ea9-a14b-857140ea02ee", "superadmin@blogapp.com", false, false, null, "SUPERADMIN@BLOGAPP.COM", "SUPERADMIN@BLOGAPP.COM", "AQAAAAEAACcQAAAAEPAOyGdcywuGQ0uq43IP1zUiA/w45COcXxZsB8fqIiOCJQQ5N/jKkv/eciAcWDdWew==", null, false, "a78378c2-a05c-43ec-ab9a-1aa63502fb46", false, "superadmin@blogapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6ac4033f-d0a4-40fa-abce-1ecbb85230d4", "55af30d8-faaf-425a-b153-1adad490dd46" },
                    { "6fba2a38-5a33-406c-a8e6-06dc54383f85", "55af30d8-faaf-425a-b153-1adad490dd46" },
                    { "eb75475b-ae2a-4076-98e3-a9bd90ba3f90", "55af30d8-faaf-425a-b153-1adad490dd46" }
                });
        }
    }
}
