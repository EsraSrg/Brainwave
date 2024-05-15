using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainWave.DataAccessLayer.Migrations
{
    public partial class resource_table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserResources",
                columns: table => new
                {
                    UserResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourcePublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResourceAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceCategories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResources", x => x.UserResourceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResources");
        }
    }
}
