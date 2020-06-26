using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDiplomProject.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeRoom",
                table: "ChatRooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRoom",
                table: "ChatRooms");
        }
    }
}
