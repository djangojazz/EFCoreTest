CREATE TABLE Flight
(
	FlightId INT Identity CONSTRAINT PK_Flight_FlightId PRIMARY KEY
,	FlightAlias varchar(128) 
,	DateCreated DateTime
,	CreatedBy Int Constraint FK_Flight_CoreUser_CreatedByUserId FOREIGN KEY References Core.Users(UserId)
,	ModifiedLast DateTime
,	ModifiedBy Int Constraint FK_Flight_CoreUser_ModifiedByUserId FOREIGN KEY References Core.Users(UserId)
)
