CREATE TABLE Flight
(
	FlightId INT CONSTRAINT PK_Flight_FlightId PRIMARY KEY
,	FlightAlias varchar(128) 
,	DateCreated DateTime
,	CreatedBy Int
,	ModifiedLast DateTime
,	ModifiedBy Int
)
