using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sat.Recruitment.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Orders_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "Orders",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 1, "Normal" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 2, "SuperUser" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[] { 3, "Premium" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
