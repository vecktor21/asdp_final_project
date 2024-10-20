using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASDP.FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Template_ContentType_field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Templates");
        }
    }
}
