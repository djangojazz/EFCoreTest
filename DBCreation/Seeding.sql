/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--Clean sweep
Set NoCount On;

truncate table Aircraft_FlightOrFlightPlan;
Delete FlightPlan
DBCC CHECKIDENT ('FlightPlan', RESEED, 0);
Delete Flight
DBCC CHECKIDENT ('Flight', RESEED, 0);
Delete Aircraft
DBCC CHECKIDENT ('Aircraft', RESEED, 0);
Delete Core.Users
DBCC CHECKIDENT ('Core.Users', RESEED, 0);

--inserts
insert into Core.Users Values ('Admin'),('Brett')
insert into Aircraft Values ('737', getdate(), 1, getdate(), 1),('747', getdate(), 2, getdate(), 2)
insert into Flight Values ('Flight1', getdate(), 1, getdate(), 1),('Flight2', getdate(), 2, getdate(), 2)
insert into FlightPlan Values (1, 'FlightPlan1-A', getdate(), 1, getdate(), 1),(1, 'FlightPlan1-B', getdate(), 1, getdate(), 1),(2, 'FlightPlan2', getdate(), 2, getdate(), 2)
insert into Aircraft_FlightOrFlightPlan Values ('Flight', 1, 1, null, getdate(), 1, getdate(), 1),('FlightPlan', 1, null, 1, getdate(), 1, getdate(), 1)
,('FlightPlan', 2, null, 2, getdate(), 1, getdate(), 1),('Flight', 2, 2, null, getdate(), 1, getdate(), 1),('FlightPlan', 2, null, 3, getdate(), 1, getdate(), 1)