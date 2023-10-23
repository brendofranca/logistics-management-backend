--DML Script

USE [logistics-management];
GO

BEGIN TRANSACTION;
GO

INSERT INTO StatusEnum (Id, StatusName)
VALUES
    (1, 'Requested'),
    (2, 'Collection'),
    (3, 'Sent'),
    (4, 'Received');

DECLARE @LocationId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @LocationId2 UNIQUEIDENTIFIER = NEWID();
DECLARE @LocationId3 UNIQUEIDENTIFIER = NEWID();
DECLARE @LocationId4 UNIQUEIDENTIFIER = NEWID();
DECLARE @LocationId5 UNIQUEIDENTIFIER = NEWID();

INSERT INTO Location (Id, LocationX, LocationY, CreatedAt, UpdatedAt)
VALUES
    (@LocationId1, 10.0, 20.0, GETDATE(), NULL),
    (@LocationId2, 15.0, 25.0, GETDATE(), NULL),
    (@LocationId3, 30.0, 40.0, GETDATE(), NULL),
    (@LocationId4, 5.0, 12.0, GETDATE(), NULL),
    (@LocationId5, 22.0, 33.0, GETDATE(), NULL);

DECLARE @GoodId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @GoodId2 UNIQUEIDENTIFIER = NEWID();
DECLARE @GoodId3 UNIQUEIDENTIFIER = NEWID();
DECLARE @GoodId4 UNIQUEIDENTIFIER = NEWID();
DECLARE @GoodId5 UNIQUEIDENTIFIER = NEWID();

INSERT INTO Good (Id, Name, LocationId, Quantity, CreatedAt, UpdatedAt)
VALUES
    (@GoodId1, 'Smartphone', @LocationId1, 100, GETDATE(), NULL),
    (@GoodId2, 'Laptop', @LocationId2, 50, GETDATE(), NULL),
    (@GoodId3, 'Television', @LocationId3, 75, GETDATE(), NULL),
    (@GoodId4, 'Tablet', @LocationId4, 120, GETDATE(), NULL),
    (@GoodId5, 'Digital Camera', @LocationId5, 60, GETDATE(), NULL);


DECLARE @AGVId1 UNIQUEIDENTIFIER = NEWID();
DECLARE @AGVId2 UNIQUEIDENTIFIER = NEWID();
DECLARE @AGVId3 UNIQUEIDENTIFIER = NEWID();
DECLARE @AGVId4 UNIQUEIDENTIFIER = NEWID();
DECLARE @AGVId5 UNIQUEIDENTIFIER = NEWID();
INSERT INTO AutomatedGuidedVehicle (Id, Name, LocationID, CreatedAt, UpdatedAt)
VALUES
    (@AGVId1, 'AGV 1', @LocationId1, GETDATE(), NULL),
    (@AGVId2, 'AGV 2', @LocationId2, GETDATE(), NULL),
    (@AGVId3, 'AGV 3', @LocationId3, GETDATE(), NULL),
    (@AGVId4, 'AGV 4', @LocationId4, GETDATE(), NULL),
    (@AGVId5, 'AGV 5', @LocationId5, GETDATE(), NULL);

COMMIT;
GO