using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sat.Recruitment.Data.Migrations
{
    public partial class init30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Orders_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "UserTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Orders_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "Orders",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
