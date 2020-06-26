using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDiplomProject.Migrations
{
    public partial class AddEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInChatRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInChatRoom",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInChatRoom", x => new { x.UserId, x.ChatRoomId });
                    table.ForeignKey(
                        name: "Relationship31",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "СостоитВЧате",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInChatRoom_ChatRoomId",
                table: "UserInChatRoom",
                column: "ChatRoomId");
        }
    }
}
