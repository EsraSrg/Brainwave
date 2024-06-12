using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequests_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests");

            migrationBuilder.DropColumn(
                name: "ProjectRequestID1",
                table: "ProjectRequests");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequests_ReceiverID",
                table: "ProjectRequests",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequests_SenderID",
                table: "ProjectRequests",
                column: "SenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequests_AspNetUsers_ReceiverID",
                table: "ProjectRequests",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequests_AspNetUsers_SenderID",
                table: "ProjectRequests",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequests_AspNetUsers_ReceiverID",
                table: "ProjectRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequests_AspNetUsers_SenderID",
                table: "ProjectRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRequests_ReceiverID",
                table: "ProjectRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRequests_SenderID",
                table: "ProjectRequests");

            migrationBuilder.AddColumn<int>(
                name: "ProjectRequestID1",
                table: "ProjectRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests",
                column: "ProjectRequestID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRequests_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests",
                column: "ProjectRequestID1",
                principalTable: "ProjectRequests",
                principalColumn: "ProjectRequestID");
        }
    }
}
