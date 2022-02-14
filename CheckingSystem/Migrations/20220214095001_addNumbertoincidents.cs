using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckingSystem.Migrations
{
    public partial class addNumbertoincidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Incidents");
        }
    }
}
