using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreCodeFirstScaffolding.Migrations
{
    public partial class AddedProcAndView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            "Create view vAircraftToFlightsAndFlightPlans as " +
            "Select " +
            "afp.AircraftFlightOrFlightPlanId " +
            ",	afp.AircraftId " +
            ",	a.AircraftName " +
            ",	afp.FlightId " +
            ",	f.FlightAlias " +
            ",	afp.FlightPlanId " +
            ",	fp.FlightPlanName " +
            ",	afp.CreatedById " +
            ",	uc.UserName as CreatedBy " +
            ",	afp.DateCreated " +
            ",	afp.ModifiedById " +
            ",	um.UserName as ModifiedBy " +
            ",	afp.ModifiedLast " +
            "from AircraftFlightOrFlightPlan afp  " +
            "  inner join Aircraft a on afp.AircraftId = a.AircraftId " +
            "  inner join Core.Users uc on afp.CreatedById = uc.UserId " +
            "  inner join Core.Users um on afp.ModifiedById = um.UserId " +
            "  left join Flight f on afp.FlightId = f.FlightId " +
            "  left join FlightPlan fp on afp.FlightPlanId = fp.FlightPlanId "
            );

            migrationBuilder.Sql(
            "create proc pGetFlightOrFlightPlan" +
            "( @ReferencedTable varchar(16) = 'Flight',	@AircraftId int,	@FlightOrFlightPlanId int) as " +
            "BEGIN " +
            "Declare @AircraftText varchar(16) = Isnull(cast(@AircraftId as varchar), 'AircraftId') " +
            "Declare @FlightOrFlightPlanText varchar(16) = Isnull(cast(@FlightOrFlightPlanId as varchar), 'FlightId') " +
            "If(@ReferencedTable = 'FlightPlan' AND  SUBSTRING(@FlightOrFlightPlanText, 1, 6) = 'Flight') " +
            "Begin Select @FlightOrFlightPlanText = Stuff(@FlightOrFlightPlanText, 7, 0, 'Plan') End " +
            "Declare @SQL nvarchar(1024) = 'Select * from vAircraftToFlightsAndFlightPlans " +
            "Where AircraftId = ' + @AircraftText + " +
            "' AND ' + @ReferencedTable + 'Id = ' + @FlightOrFlightPlanText " +
            "exec sp_executesql @SQL " +
            "END"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view vAircraftToFlightsAndFlightPlans");
            migrationBuilder.Sql("drop proc pGetFlightOrFlightPlan");
        }
    }
}
