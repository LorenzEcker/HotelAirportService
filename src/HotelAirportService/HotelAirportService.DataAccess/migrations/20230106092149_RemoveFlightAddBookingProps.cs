using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAirportService.DataAccess.migrations
{
    /// <inheritdoc />
    public partial class RemoveFlightAddBookingProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customer_Id",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Customer_Id",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Driver_Id",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Flight_Id",
                table: "Ride");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropColumn(
                name: "HasFreeTransfer",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "AmmountOfLuggage",
                table: "Customer",
                newName: "AmountOfLuggage");

            migrationBuilder.AddColumn<Guid>(
                name: "AirportId",
                table: "Ride",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Ride",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Ride",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BookingCode",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Booking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Ride_AirportId",
                table: "Ride",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_CustomerId",
                table: "Ride",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_DriverId",
                table: "Ride",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Airport_AirportId",
                table: "Ride",
                column: "AirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Customer_CustomerId",
                table: "Ride",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Driver_DriverId",
                table: "Ride",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Airport_AirportId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Customer_CustomerId",
                table: "Ride");

            migrationBuilder.DropForeignKey(
                name: "FK_Ride_Driver_DriverId",
                table: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Ride_AirportId",
                table: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Ride_CustomerId",
                table: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Ride_DriverId",
                table: "Ride");

            migrationBuilder.DropIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Ride");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Ride");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Ride");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingCode",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "AmountOfLuggage",
                table: "Customer",
                newName: "AmmountOfLuggage");

            migrationBuilder.AddColumn<bool>(
                name: "HasFreeTransfer",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customer_Id",
                table: "Booking",
                column: "Id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Customer_Id",
                table: "Ride",
                column: "Id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Driver_Id",
                table: "Ride",
                column: "Id",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ride_Flight_Id",
                table: "Ride",
                column: "Id",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
