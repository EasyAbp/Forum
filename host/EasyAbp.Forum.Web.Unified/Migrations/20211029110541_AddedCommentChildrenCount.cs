using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Forum.Migrations
{
    public partial class AddedCommentChildrenCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildrenCount",
                table: "EasyAbpForumComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildrenCount",
                table: "EasyAbpForumComments");
        }
    }
}
