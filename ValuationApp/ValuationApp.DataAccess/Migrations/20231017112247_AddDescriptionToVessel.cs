using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToVessel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vessels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vessels");
        }
    }
}
