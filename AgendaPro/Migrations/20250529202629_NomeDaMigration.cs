using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaPro.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Remove as adições das colunas já existentes
            // migrationBuilder.AddColumn<string>(
            //     name: "Description",
            //     table: "Services",
            //     type: "nvarchar(500)",
            //     maxLength: 500,
            //     nullable: true);

            // migrationBuilder.AddColumn<decimal>(
            //     name: "Price",
            //     table: "Services",
            //     type: "decimal(18,2)",
            //     nullable: false,
            //     defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Description",
            //     table: "Services");

            // migrationBuilder.DropColumn(
            //     name: "Price",
            //     table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
