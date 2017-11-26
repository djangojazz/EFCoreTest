Create view vAircraftToFlightsAndFlightPlans
as
Select
	afp.AircraftFlightOrFlightPlanId
,	afp.AircraftId
,	a.AircraftName
,	afp.FlightId
,	f.FlightAlias
,	afp.FlightPlanId
,	fp.FlightPlanName
,	afp.CreatedById
,	uc.UserName as CreatedBy
,	afp.DateCreated
,	afp.ModifiedById
,	um.UserName as ModifiedBy
,	afp.ModifiedLast
from AircraftFlightOrFlightPlan afp 
	inner join Aircraft a on afp.AircraftId = a.AircraftId
	inner join Core.Users uc on afp.CreatedById = uc.UserId
	inner join Core.Users um on afp.ModifiedById = um.UserId
	left join Flight f on afp.FlightId = f.FlightId
	left join FlightPlan fp on afp.FlightPlanId = fp.FlightPlanId