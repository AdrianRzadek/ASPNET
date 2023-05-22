using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Migrations
{
    /// <inheritdoc />
    public partial class AU2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vehicles",
                newName: "VehicleName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Vehicles",
                newName: "VehicleMark");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Vehicles",
                newName: "VehicleId");

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehiclePrice",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleColor",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehiclePrice",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleName",
                table: "Vehicles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VehicleMark",
                table: "Vehicles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Vehicles",
                newName: "ID");
        }
    }
}
