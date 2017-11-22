CREATE TABLE FlightPlan
(
	FlightPlanId INT Identity CONSTRAINT PK_FLightPlan_FlightPlanId PRIMARY KEY
,	FlightId INT CONSTRAINT FK_FlightPlan_Flight_FlightId FOREIGN KEY REFERENCES Flight(FlightId)
,	FlightPlanName VARCHAR(128)
,	DateCreated DateTime
,	CreatedBy Int Constraint FK_FlightPlan_CoreUser_CreatedByUserId FOREIGN KEY References Core.Users(UserId)
,	ModifiedLast DateTime
,	ModifiedBy Int Constraint FK_FlightPlan_CoreUser_ModifiedByUserId FOREIGN KEY References Core.Users(UserId)
)
