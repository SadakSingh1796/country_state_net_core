using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurdCountryAndState.Migrations
{
    /// <inheritdoc />
    public partial class MyDemoMigrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Coutries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Coutries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_Tbl_States_Tbl_Coutries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Tbl_Coutries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_States_CountryId",
                table: "Tbl_States",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_States");

            migrationBuilder.DropTable(
                name: "Tbl_Coutries");
        }
    }
}
