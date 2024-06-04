using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class userRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserParticipatingProjects");

            migrationBuilder.CreateTable(
                name: "UserRequests",
                columns: table => new
                {
                    UserRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    SenderUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverID = table.Column<int>(type: "int", nullable: true),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserRequestID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequests", x => x.UserRequestID);
                    table.ForeignKey(
                        name: "FK_UserRequests_UserRequests_UserRequestID1",
                        column: x => x.UserRequestID1,
                        principalTable: "UserRequests",
                        principalColumn: "UserRequestID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_UserRequestID1",
                table: "UserRequests",
                column: "UserRequestID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRequests");

            migrationBuilder.CreateTable(
                name: "UserParticipatingProjects",
                columns: table => new
                {
                    UserParticipatingProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserParticipatingProjects", x => x.UserParticipatingProjectID);
                });
        }
    }
}
