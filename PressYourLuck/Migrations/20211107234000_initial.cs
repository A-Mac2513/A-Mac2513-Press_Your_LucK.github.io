using Microsoft.EntityFrameworkCore.Migrations;

namespace PressYourLuck.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTypes",
                columns: table => new
                {
                    AuditTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTypes", x => x.AuditTypeId);
                });

            migrationBuilder.InsertData(
                table: "AuditTypes",
                columns: new[] { "AuditTypeId", "Name" },
                values: new object[,]
                {
                    { "ci", "Cash In" },
                    { "co", "Cash Out" },
                    { "w", "Win" },
                    { "l", "Lose" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTypes");
        }
    }
}
