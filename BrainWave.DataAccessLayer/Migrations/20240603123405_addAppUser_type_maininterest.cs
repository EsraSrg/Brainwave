using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class addAppUser_type_maininterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainInterest",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainInterest",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");
        }
    }
}
