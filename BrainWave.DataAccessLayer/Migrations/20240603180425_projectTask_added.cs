using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class projectTask_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    ReceiverUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverID = table.Column<int>(type: "int", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskFinishedNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProjectTaskID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ProjectTaskID);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_ProjectTasks_ProjectTaskID1",
                        column: x => x.ProjectTaskID1,
                        principalTable: "ProjectTasks",
                        principalColumn: "ProjectTaskID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectTaskID1",
                table: "ProjectTasks",
                column: "ProjectTaskID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTasks");
        }
    }
}
