CREATE TABLE Aircraft_FlightOrFlightPlan
(
	AircraftFlightOrFlightPlanId INT CONSTRAINT PK_AircraftFlightOrFlightPlan_AircraftFlightOrFlightPlanId PRIMARY KEY
,	ReferencedTable Varchar(128) NOT NULL
,	AircraftId INT CONSTRAINT FK_AircraftFlightOrFlightPlan_Aircraft_AircraftId FOREIGN KEY REFERENCES Aircraft(AircraftId)
,	FlightId INT CONSTRAINT FK_AircraftFlightOrFlightPlan_Flight_FlightId FOREIGN KEY REFERENCES Flight(FlightId)
,	FlightPlanId INT CONSTRAINT FK_AircraftFlightOrFlightPlan_FlightPlan_FlightPlanId FOREIGN KEY REFERENCES FlightPlan(FlightPlanId)
,	DateCreated DateTime
,	CreatedBy Int
,	ModifiedLast DateTime
,	ModifiedBy Int
)
