using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDiplomProject.Migrations
{
    public partial class addComents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coments",
                columns: table => new
                {
                    ComentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coment = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ChildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coments", x => x.ComentId);
                    table.ForeignKey(
                        name: "КомментарийКРебёнку",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationship55",
                table: "Coments",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coments");
        }
    }
}
