using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class user_project_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ProjectStatus",
                table: "UserProjects",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ProjectCategories",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProjectPrivacy",
                table: "UserProjects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectSources",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectTasks",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectTools",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCategories",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProjectPrivacy",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProjectSources",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProjectTasks",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProjectTools",
                table: "UserProjects");

            migrationBuilder.AlterColumn<bool>(
                name: "ProjectStatus",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
