using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMainMarket.DataAccess.Migrations
{
    public partial class AddTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    JwtId = table.Column<string>(type: "text", nullable: true),
                    Invalidated = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.RefreshToken);
                    table.ForeignKey(
                        name: "FK_Tokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");
        }
    }
}
