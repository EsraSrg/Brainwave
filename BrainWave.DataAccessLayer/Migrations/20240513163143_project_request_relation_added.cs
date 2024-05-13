using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class project_request_relation_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectRequest",
                columns: table => new
                {
                    ProjectRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    ReceiverID = table.Column<int>(type: "int", nullable: true),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequest", x => x.ProjectRequestID);
                    table.ForeignKey(
                        name: "FK_ProjectRequest_UserProjects_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "UserProjects",
                        principalColumn: "UserProjectID");
                    table.ForeignKey(
                        name: "FK_ProjectRequest_UserProjects_SenderID",
                        column: x => x.SenderID,
                        principalTable: "UserProjects",
                        principalColumn: "UserProjectID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequest_ReceiverID",
                table: "ProjectRequest",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequest_SenderID",
                table: "ProjectRequest",
                column: "SenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRequest");
        }
    }
}
