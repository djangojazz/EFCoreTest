CREATE TABLE Aircraft
(
	AircraftId INT Identity Constraint PK_Aircraft_AircraftId PRIMARY KEY
,	AircraftName varchar(128)
,	DateCreated DateTime
,	CreatedById Int Constraint FK_Aircraft_CoreUser_CreatedByUserId FOREIGN KEY References Core.Users(UserId)
,	ModifiedLast DateTime
,	ModifiedById Int Constraint FK_Aircraft_CoreUser_ModifiedByUserId FOREIGN KEY References Core.Users(UserId)
)
