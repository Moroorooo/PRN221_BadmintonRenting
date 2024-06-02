using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonRentingData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BadmintonField",
                columns: table => new
                {
                    BadmintonFieldID = table.Column<long>(type: "bigint", nullable: false),
                    BadmintonFieldName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsStatus = table.Column<bool>(type: "bit", unicode: false, fixedLength: true, maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadmintonField", x => x.BadmintonFieldID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    IsStatus = table.Column<string>(type: "char(55)", unicode: false, fixedLength: true, maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    StartTimeFrame = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTimeFrame = table.Column<TimeSpan>(type: "time", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalHours = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    BookingType = table.Column<string>(type: "char(55)", unicode: false, fixedLength: true, maxLength: 55, nullable: false),
                    CheckInStatus = table.Column<bool>(type: "bit", nullable: true),
                    IsStatus = table.Column<string>(type: "char(55)", unicode: false, fixedLength: true, maxLength: 55, nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentType = table.Column<string>(type: "char(55)", unicode: false, fixedLength: true, maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK__Booking__UserId__398D8EEE",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Booking_BadmintonField_Schedule",
                columns: table => new
                {
                    OrderBadmintonFieldScheduleID = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    BookingId = table.Column<long>(type: "bigint", nullable: false),
                    BadmintonField = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Booking___750D09A512DD8A23", x => x.OrderBadmintonFieldScheduleID);
                    table.ForeignKey(
                        name: "FK__Booking_B__Badmi__403A8C7D",
                        column: x => x.BadmintonField,
                        principalTable: "BadmintonField",
                        principalColumn: "BadmintonFieldID");
                    table.ForeignKey(
                        name: "FK__Booking_B__Booki__403A8C7D",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK__Booking_B__Sched__4222D4EF",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BadmintonField_Schedule_BadmintonField",
                table: "Booking_BadmintonField_Schedule",
                column: "BadmintonField");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BadmintonField_Schedule_BookingId",
                table: "Booking_BadmintonField_Schedule",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BadmintonField_Schedule_ScheduleId",
                table: "Booking_BadmintonField_Schedule",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_BadmintonField_Schedule");

            migrationBuilder.DropTable(
                name: "BadmintonField");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
