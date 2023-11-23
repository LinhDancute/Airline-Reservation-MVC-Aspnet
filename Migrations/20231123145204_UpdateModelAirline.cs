using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineReservationVietjet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelAirline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Airline",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Airline",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Airline");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Airline");
        }
    }
}
