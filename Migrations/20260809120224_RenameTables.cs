using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyShelterReadinessSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inspections_shelters_ShelterId",
                table: "inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_shelters_Areas_AreaId",
                table: "shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shelters",
                table: "shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inspections",
                table: "inspections");

            migrationBuilder.RenameTable(
                name: "shelters",
                newName: "Shelters");

            migrationBuilder.RenameTable(
                name: "inspections",
                newName: "Inspections");

            migrationBuilder.RenameIndex(
                name: "IX_shelters_AreaId",
                table: "Shelters",
                newName: "IX_Shelters_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_inspections_ShelterId",
                table: "Inspections",
                newName: "IX_Inspections_ShelterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelters",
                table: "Shelters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Shelters_ShelterId",
                table: "Inspections",
                column: "ShelterId",
                principalTable: "Shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelters_Areas_AreaId",
                table: "Shelters",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Shelters_ShelterId",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelters_Areas_AreaId",
                table: "Shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelters",
                table: "Shelters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections");

            migrationBuilder.RenameTable(
                name: "Shelters",
                newName: "shelters");

            migrationBuilder.RenameTable(
                name: "Inspections",
                newName: "inspections");

            migrationBuilder.RenameIndex(
                name: "IX_Shelters_AreaId",
                table: "shelters",
                newName: "IX_shelters_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_ShelterId",
                table: "inspections",
                newName: "IX_inspections_ShelterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shelters",
                table: "shelters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inspections",
                table: "inspections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inspections_shelters_ShelterId",
                table: "inspections",
                column: "ShelterId",
                principalTable: "shelters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shelters_Areas_AreaId",
                table: "shelters",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
