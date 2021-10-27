using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Forum.Migrations
{
    public partial class AddedPostPinnedAndThumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pinned",
                table: "EasyAbpForumPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "EasyAbpForumPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pinned",
                table: "EasyAbpForumPosts");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "EasyAbpForumPosts");
        }
    }
}
