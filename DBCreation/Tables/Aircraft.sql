CREATE TABLE Aircraft
(
	AircraftId INT Constraint PK_Aircraft_AircraftId PRIMARY KEY
,	AircraftName varchar(128)
,	DateCreated DateTime
,	CreatedBy Int Constraint FK_Aircraft_CoreUser_CreatedByUserId FOREIGN KEY References Core.Users(UserId)
,	ModifiedLast DateTime
,	ModifiedBy Int Constraint FK_Aircraft_CoreUser_ModifiedByUserId FOREIGN KEY References Core.Users(UserId)
)
