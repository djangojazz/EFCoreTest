CREATE TABLE FlightPlan
(
	FlightPlanId INT CONSTRAINT PK_FLightPlan_FlightPlanId PRIMARY KEY
,	FlightId INT CONSTRAINT FK_FlightPlan_Flight_FlightId FOREIGN KEY REFERENCES Flight(FlightId)
,	FlightPlanName VARCHAR(128)
,	DateCreated DateTime
,	CreatedBy Int
,	ModifiedLast DateTime
,	ModifiedBy Int
)
