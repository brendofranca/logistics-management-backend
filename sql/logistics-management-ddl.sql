--DDL Script

CREATE DATABASE [logistics-management];
GO

USE [logistics-management];
GO

BEGIN TRANSACTION
GO

CREATE TABLE StatusEnum (
    Id INT PRIMARY KEY,
    StatusName NVARCHAR(255) NOT NULL
);

CREATE TABLE RequestStatus (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    StatusId INT,
	RequestId UNIQUEIDENTIFIER,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
);
GO

CREATE TABLE Request (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Description NVARCHAR(255) NOT NULL,
    RequestStatusId UNIQUEIDENTIFIER,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,   
    INDEX IX_Request_Description (Description)
);
GO

ALTER TABLE RequestStatus
ADD CONSTRAINT FK_RequestStatus_StatusEnum
FOREIGN KEY (StatusId)
REFERENCES StatusEnum(Id);
GO

ALTER TABLE RequestStatus
ADD CONSTRAINT FK_RequestStatus_Request
FOREIGN KEY (RequestId)
REFERENCES Request(Id);
GO

ALTER TABLE Request
ADD CONSTRAINT FK_Request_RequestStatus
FOREIGN KEY (RequestStatusId)
REFERENCES RequestStatus(Id);
GO

CREATE TABLE Location (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    LocationX DECIMAL(10, 2) NOT NULL,
    LocationY DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL  
);
GO

CREATE TABLE Good (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    LocationId UNIQUEIDENTIFIER,
    Quantity INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (LocationId) REFERENCES Location(Id),
    INDEX IX_Good_Name (Name)
);
GO

CREATE TABLE AutomatedGuidedVehicle (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(255) NOT NULL,
    LocationId UNIQUEIDENTIFIER,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (LocationId) REFERENCES Location(Id),
    INDEX IX_AutomatedGuidedVehicle_Name (Name)
);
GO

CREATE TABLE RequestItem (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    RequestId UNIQUEIDENTIFIER,
    GoodId UNIQUEIDENTIFIER,
    Quantity INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (RequestId) REFERENCES Request(Id),
    FOREIGN KEY (GoodId) REFERENCES Good(Id),
    INDEX IX_RequestItem_RequestId (RequestId),
    INDEX IX_RequestItem_GoodId (GoodId)
);
GO

COMMIT;
GO