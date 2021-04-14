using Microsoft.EntityFrameworkCore.Migrations;

namespace api2.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Tasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
