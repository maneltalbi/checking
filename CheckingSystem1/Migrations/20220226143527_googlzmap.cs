using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckingSystem1.Migrations
{
    public partial class googlzmap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMap",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IdMap",
                table: "Incidents",
                column: "IdMap");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_GoogleMap_IdMap",
                table: "Incidents",
                column: "IdMap",
                principalTable: "GoogleMap",
                principalColumn: "IdMap",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_GoogleMap_IdMap",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_IdMap",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "IdMap",
                table: "Incidents");
        }
    }
}
