using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Core",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    AircraftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedLast = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_Aircraft_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aircraft_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DateTime", nullable: true),
                    FlightAlias = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedLast = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flight_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightPlan",
                columns: table => new
                {
                    FlightPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(nullable: true),
                    FlightPlanName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPlan", x => x.FlightPlanId);
                    table.ForeignKey(
                        name: "FK_FlightPlan_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AircraftFlightOrFlightPlan",
                columns: table => new
                {
                    AircraftFlightOrFlightPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DateTime", nullable: true),
                    FlightId = table.Column<int>(nullable: true),
                    FlightPlanId = table.Column<int>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedLast = table.Column<DateTime>(type: "DateTime", nullable: true),
                    ReferencedTable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftFlightOrFlightPlan", x => x.AircraftFlightOrFlightPlanId);
                    table.ForeignKey(
                        name: "FK_AircraftFlightOrFlightPlan_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlightOrFlightPlan_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlightOrFlightPlan_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlightOrFlightPlan_FlightPlan_FlightPlanId",
                        column: x => x.FlightPlanId,
                        principalTable: "FlightPlan",
                        principalColumn: "FlightPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlightOrFlightPlan_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "Core",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_CreatedById",
                table: "Aircraft",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_ModifiedById",
                table: "Aircraft",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlightOrFlightPlan_AircraftId",
                table: "AircraftFlightOrFlightPlan",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlightOrFlightPlan_CreatedById",
                table: "AircraftFlightOrFlightPlan",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlightOrFlightPlan_FlightId",
                table: "AircraftFlightOrFlightPlan",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlightOrFlightPlan_FlightPlanId",
                table: "AircraftFlightOrFlightPlan",
                column: "FlightPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlightOrFlightPlan_ModifiedById",
                table: "AircraftFlightOrFlightPlan",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CreatedById",
                table: "Flight",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ModifiedById",
                table: "Flight",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPlan_FlightId",
                table: "FlightPlan",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftFlightOrFlightPlan");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "FlightPlan");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Core");
        }
    }
}
