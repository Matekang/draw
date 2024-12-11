using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrawPicture.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class _121124 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "DrawStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "DrawStudents");
        }
    }
}
