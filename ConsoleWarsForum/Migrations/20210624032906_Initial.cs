using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleWarsForum.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateAndTimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Username = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    ThreadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateAndTimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.ThreadId);
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "Body", "DateAndTimeStamp", "Title" },
                values: new object[] { 1, "Everyone knows that Sega does with NintenDON'T", new DateTime(2021, 6, 23, 20, 29, 5, 650, DateTimeKind.Local).AddTicks(575), "Sega Genesis vs Super Nintendo Entertainment System" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "Body", "DateAndTimeStamp", "Title" },
                values: new object[] { 2, "PlayStation was the clear winner", new DateTime(2021, 6, 23, 20, 29, 5, 650, DateTimeKind.Local).AddTicks(1301), "Nintendo 64 vs Sony PlayStation vs Sega Saturn" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadId", "Body", "DateAndTimeStamp", "Title" },
                values: new object[] { 3, "The Xbox was the best because it had Halo", new DateTime(2021, 6, 23, 20, 29, 5, 650, DateTimeKind.Local).AddTicks(1316), "PlayStation 2 vs Nintendo GameCube vs Microsoft Xbox vs Sega Dreamcast" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Threads");
        }
    }
}
