using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyShelterReadinessSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updtateShlterType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShelterType",
                table: "Shelters",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "string");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShelterType",
                table: "Shelters",
                type: "string",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
