CREATE TABLE Aircraft
(
	AircraftId INT Constraint PK_Aircraft_AircraftId PRIMARY KEY
,	AircraftName varchar(128)
,	DateCreated DateTime
,	CreatedBy Int
,	ModifiedLast DateTime
,	ModifiedBy Int
)
