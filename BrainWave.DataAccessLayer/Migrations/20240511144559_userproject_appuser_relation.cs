using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class userproject_appuser_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "UserProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_AppUserID",
                table: "UserProjects",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_AspNetUsers_AppUserID",
                table: "UserProjects",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_AspNetUsers_AppUserID",
                table: "UserProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserProjects_AppUserID",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "UserProjects");
        }
    }
}
