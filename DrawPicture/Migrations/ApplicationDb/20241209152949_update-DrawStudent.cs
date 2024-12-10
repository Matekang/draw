using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrawPicture.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class updateDrawStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DrawStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DrawStudents");
        }
    }
}
