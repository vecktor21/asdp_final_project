using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASDP.FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Employee_remove_password_add_Document_signs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "SigexSignId",
                table: "SignPipeline",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "SigexDocumentId",
                table: "SignDocuments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SigexSignId",
                table: "SignPipeline");

            migrationBuilder.DropColumn(
                name: "SigexDocumentId",
                table: "SignDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
