using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASDP.FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class fix_position_permission_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionPosition");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "PositionPermission",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "PositionPermission",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PositionPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PermissionId", "PositionId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "PositionPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PermissionId", "PositionId" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPermission_PermissionId",
                table: "PositionPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPermission_PositionId",
                table: "PositionPermission",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermission_Permissions_PermissionId",
                table: "PositionPermission",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermission_Positions_PositionId",
                table: "PositionPermission",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermission_Permissions_PermissionId",
                table: "PositionPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermission_Positions_PositionId",
                table: "PositionPermission");

            migrationBuilder.DropIndex(
                name: "IX_PositionPermission_PermissionId",
                table: "PositionPermission");

            migrationBuilder.DropIndex(
                name: "IX_PositionPermission_PositionId",
                table: "PositionPermission");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "PositionPermission");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "PositionPermission");

            migrationBuilder.CreateTable(
                name: "PermissionPosition",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPosition", x => new { x.PermissionsId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PermissionPosition_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPosition_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPosition_PositionId",
                table: "PermissionPosition",
                column: "PositionId");
        }
    }
}
