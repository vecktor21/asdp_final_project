using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASDP.FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Template_Code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateCode",
                table: "Templates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TemplateCode",
                table: "Templates",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
