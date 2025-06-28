using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaPro.Migrations
{
    /// <inheritdoc />
    public partial class AddIsMasterToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "Users");
        }
    }
}
