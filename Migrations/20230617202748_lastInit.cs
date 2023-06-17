using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _423_proj.Migrations
{
    /// <inheritdoc />
    public partial class lastInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    AdvertisementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerUpperLimit = table.Column<int>(type: "int", nullable: false),
                    FollowerBottomLimit = table.Column<int>(type: "int", nullable: false),
                    ViewsBottomLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.AdvertisementID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    e_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiktokAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiktokFollowerCount = table.Column<int>(type: "int", nullable: false),
                    InstagramFollowerCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    PricePerPerson = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_Advertisements_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisements",
                        principalColumn: "AdvertisementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShareURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "AdvertisementID", "FollowerBottomLimit", "FollowerUpperLimit", "ViewsBottomLimit" },
                values: new object[] { 1, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeID", "UserTypeName" },
                values: new object[] { 1, "Influencer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "InstagramAccount", "InstagramFollowerCount", "Name", "NameSurname", "Password", "TiktokAccount", "TiktokFollowerCount", "UserTypeID", "e_mail" },
                values: new object[] { 1, null, 0, "metinabadan", "Metin Abadan", "metinabadan06", null, 0, 1, "metinabadan@gmail.com" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "AdvertisementID", "Description", "PricePerPerson", "Quota", "Title", "UserID" },
                values: new object[] { 1, 1, "ExampleDescription", 1.0, 1, "ExampleTitle", 1 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentID", "PostID", "ShareURL", "UserID" },
                values: new object[] { 1, 1, "ExampleDescription123", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostID",
                table: "Comment",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AdvertisementID",
                table: "Posts",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
