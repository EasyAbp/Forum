using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.Forum.Migrations
{
    public partial class UpgradedToAbp601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EasyAbpForumUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EasyAbpForumUsers");
        }
    }
}
