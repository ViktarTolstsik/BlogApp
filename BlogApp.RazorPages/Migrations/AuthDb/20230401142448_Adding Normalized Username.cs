using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.RazorPages.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingNormalizedUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55af30d8-faaf-425a-b153-1adad490dd46",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2958dc09-9385-4ea9-a14b-857140ea02ee", "SUPERADMIN@BLOGAPP.COM", "SUPERADMIN@BLOGAPP.COM", "AQAAAAEAACcQAAAAEPAOyGdcywuGQ0uq43IP1zUiA/w45COcXxZsB8fqIiOCJQQ5N/jKkv/eciAcWDdWew==", "a78378c2-a05c-43ec-ab9a-1aa63502fb46" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55af30d8-faaf-425a-b153-1adad490dd46",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3de9aed-5a97-49b1-ae67-6fd3ea157aad", null, null, "AQAAAAEAACcQAAAAEKNqWT3VjGBA/qGWrKZFaZUGsd4j+BsoxssGA9vLrT5a0oAhY/c5gYSpkQQLjOm1uA==", "8b589b99-c143-4709-ba47-7e53ffbe2978" });
        }
    }
}
