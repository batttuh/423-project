using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _423_proj.Migrations
{
    /// <inheritdoc />
    public partial class CreateComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Comment",
                 columns: table => new
                 {
                     CommentID = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     UserID = table.Column<int>(type: "int", nullable: false),
                     PostID = table.Column<int>(type: "int", nullable: false),
                     Description = table.Column<string>(nullable: false)

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


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}











