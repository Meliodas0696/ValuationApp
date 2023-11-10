using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuationApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBundleAndValuations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Vessels",
                newName: "Vessels",
                newSchema: "dbo");

            migrationBuilder.CreateTable(
                name: "Bundles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valuations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatedValue = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VesselId = table.Column<int>(type: "int", nullable: false),
                    BundleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valuations_Bundles_VesselId",
                        column: x => x.VesselId,
                        principalSchema: "dbo",
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Valuations_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalSchema: "dbo",
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valuations_VesselId",
                schema: "dbo",
                table: "Valuations",
                column: "VesselId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valuations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bundles",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "Vessels",
                schema: "dbo",
                newName: "Vessels");
        }
    }
}
