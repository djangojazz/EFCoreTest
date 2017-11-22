create proc pGetFlightOrFlightPlan
	(
		@ReferencedTable varchar(16) = 'Flight'
	,	@AircraftId int
	,	@FlightOrFlightPlanId int
	)
as 
BEGIN
	Declare @AircraftText varchar(16) = Isnull(cast(@AircraftId as varchar), 'AircraftId')
	Declare @FlightOrFlightPlanText varchar(16) = Isnull(cast(@FlightOrFlightPlanId as varchar), 'FlightId')
	If(@ReferencedTable = 'FlightPlan' AND  SUBSTRING(@FlightOrFlightPlanText, 1, 6) = 'Flight')
	Begin
		Select @FlightOrFlightPlanText = Stuff(@FlightOrFlightPlanText, 7, 0, 'Plan')
	End

	Declare @SQL nvarchar(1024) = 'Select * from vAircraftToFlightsAndFlightPlans 
		Where AircraftId = ' + @AircraftText +
		' AND ' + @ReferencedTable + 'Id = ' + @FlightOrFlightPlanText 

	exec sp_executesql @SQL
	--print @SQL
END