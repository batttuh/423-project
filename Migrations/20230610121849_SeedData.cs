using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _423_proj.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TiktokAccount",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstagramAccount",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "AdvertisementID", "FollowerBottomLimit", "FollowerUpperLimit", "ViewsBottomLimit" },
                values: new object[] { 1, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "UserTypeName" },
                values: new object[] { 1, "Influencer" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "AdvertisementID", "Description", "PricePerPerson", "Quota", "Title" },
                values: new object[] { 1, 1, "ExampleDescription", 1.0, 1, "ExampleTitle" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "InstagramAccount", "InstagramFollowerCount", "Name", "NameSurname", "Password", "PostID", "TiktokAccount", "TiktokFollowerCount", "UserTypeID", "e_mail" },
                values: new object[] { 1, null, 0, "metinabadan", "Metin Abadan", "metinabadan06", 1, null, 0, 1, "metinabadan@gmail.com" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationID", "PostID", "ShareURL", "UserID" },
                values: new object[] { 1, 1, "URL", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "ApplicationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "AdvertisementID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "TiktokAccount",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstagramAccount",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
