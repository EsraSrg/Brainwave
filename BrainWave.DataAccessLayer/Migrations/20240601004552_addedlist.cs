using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class addedlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectRequestID1",
                table: "ProjectRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserParticipatingProjects",
                columns: table => new
                {
                    UserParticipatingProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParticipatingProjects", x => x.UserParticipatingProjectID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRequests_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests");

            migrationBuilder.DropTable(
                name: "UserParticipatingProjects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRequests_ProjectRequestID1",
                table: "ProjectRequests");

            migrationBuilder.DropColumn(
                name: "ProjectRequestID1",
                table: "ProjectRequests");
        }
    }
}
