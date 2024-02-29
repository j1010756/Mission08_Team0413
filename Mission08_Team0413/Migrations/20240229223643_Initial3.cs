using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission08_Team0413.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char>(
                name: "Task",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: '\0');
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Task",
                table: "Tasks");
        }
    }
}
