--MeetingLoggerDB

Use master
CREATE Database MeetingLoggerDB
GO

Use MeetingLoggerDB
GO

CREATE TABLE Corporate_Customer_Tbl (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100)
);
GO

CREATE TABLE Individual_Customer_Tbl (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100)
);
GO

CREATE TABLE Products_Service_Tbl (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Unit VARCHAR(50)
);
GO

CREATE TABLE Meeting_Minutes_Master_Tbl (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerType VARCHAR(20),
    CustomerName VARCHAR(100),
    MeetingDate DATE,
    MeetingTime TIME
);
GO

USE MeetingLoggerDB;
GO 

-- Alter Meeting_Minutes_Master_Tbl to add new fields
ALTER TABLE Meeting_Minutes_Master_Tbl
ADD MeetingPlace VARCHAR(100),
    AttendsFromClientSide VARCHAR(100),
    AttendsFromHostSide VARCHAR(100),
    MeetingAgenda NVARCHAR(MAX),
    MeetingDiscussion NVARCHAR(MAX),
    MeetingDecision NVARCHAR(MAX);
GO


CREATE TABLE Meeting_Minutes_Details_Tbl (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MeetingId INT,
    ProductId INT,
    Quantity INT,
    FOREIGN KEY (MeetingId) REFERENCES Meeting_Minutes_Master_Tbl(Id),
    FOREIGN KEY (ProductId) REFERENCES Products_Service_Tbl(Id)
);
GO

CREATE PROCEDURE Meeting_Minutes_Master_Save_SP
    @CustomerType VARCHAR(20),
    @CustomerName VARCHAR(100),
    @MeetingDate DATE,
    @MeetingTime TIME
AS
BEGIN
    INSERT INTO Meeting_Minutes_Master_Tbl (CustomerType, CustomerName, MeetingDate, MeetingTime)
    VALUES (@CustomerType, @CustomerName, @MeetingDate, @MeetingTime)
END;
GO

USE MeetingLoggerDB;
GO

-- Alter the existing stored procedure
ALTER PROCEDURE Meeting_Minutes_Master_Save_SP
    @CustomerType VARCHAR(20),
    @CustomerName VARCHAR(100),
    @MeetingDate DATE,
    @MeetingTime TIME,
    @MeetingPlace VARCHAR(100),
    @AttendsFromClientSide VARCHAR(100),
    @AttendsFromHostSide VARCHAR(100),
    @MeetingAgenda NVARCHAR(MAX),
    @MeetingDiscussion NVARCHAR(MAX),
    @MeetingDecision NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Meeting_Minutes_Master_Tbl (CustomerType, CustomerName, MeetingDate, MeetingTime, MeetingPlace, AttendsFromClientSide, AttendsFromHostSide, MeetingAgenda, MeetingDiscussion, MeetingDecision)
    VALUES (@CustomerType, @CustomerName, @MeetingDate, @MeetingTime, @MeetingPlace, @AttendsFromClientSide, @AttendsFromHostSide, @MeetingAgenda, @MeetingDiscussion, @MeetingDecision)
END;
GO

CREATE PROCEDURE Meeting_Minutes_Details_Save_SP
    @MeetingId INT,
    @ProductId INT,
    @Quantity INT
AS
BEGIN
    INSERT INTO Meeting_Minutes_Details_Tbl (MeetingId, ProductId, Quantity)
    VALUES (@MeetingId, @ProductId, @Quantity)
END;
GO

-- Sample data insert
USE MeetingLoggerDB;
GO

-- Insert data into Corporate_Customer_Tbl
INSERT INTO Corporate_Customer_Tbl (CustomerName)
VALUES ('ABC Corp'), ('XYZ Inc'), ('LMN Enterprises');
GO

-- Insert data into Individual_Customer_Tbl
INSERT INTO Individual_Customer_Tbl (CustomerName)
VALUES ('John Doe'), ('Jane Smith'), ('Alex Johnson');
GO

-- Insert data into Products_Service_Tbl
INSERT INTO Products_Service_Tbl (ProductName, Unit)
VALUES ('Product A', 'Unit A'), ('Product B', 'Unit B'), ('Product C', 'Unit C');
GO

---- Insert data into Meeting_Minutes_Master_Tbl
--INSERT INTO Meeting_Minutes_Master_Tbl (CustomerType, CustomerName, MeetingDate, MeetingTime)
--VALUES 
--    ('Corporate', 'ABC Corp', '2023-01-15', '09:30:00'),
--    ('Individual', 'John Doe', '2023-01-20', '14:00:00'),
--    ('Corporate', 'LMN Enterprises', '2023-01-25', '11:45:00');
--GO

USE MeetingLoggerDB;
GO

-- Insert additional data into Meeting_Minutes_Master_Tbl
INSERT INTO Meeting_Minutes_Master_Tbl (CustomerType, CustomerName, MeetingDate, MeetingTime, MeetingPlace, AttendsFromClientSide, AttendsFromHostSide, MeetingAgenda, MeetingDiscussion, MeetingDecision)
VALUES 
    ('Corporate', 'ABC Corp', '2023-01-15', '09:30:00', 'Board Room A', 'XYZ Team', 'ABC Corporation', 'Quarterly Review', 'Financial Performance Review', 'Action Items Defined'),
    ('Individual', 'John Doe', '2023-01-20', '14:00:00', 'Meeting Room B', 'John Doe', 'IT Department', 'New Project Proposal', 'Technology Stack Discussion', 'Approved for Initial Development'),
    ('Corporate', 'LMN Enterprises', '2023-01-25', '11:45:00', 'Conference Hall C', 'LMN Management', 'External Consultants', 'Strategic Planning', 'Market Analysis and Strategy', 'Plan for Expansion Finalized');
GO

-- Insert data into Meeting_Minutes_Details_Tbl
INSERT INTO Meeting_Minutes_Details_Tbl (MeetingId, ProductId, Quantity)
VALUES 
    (1, 1, 10),
    (2, 2, 5),
    (3, 3, 8);
GO

---- Save data using store procedure.
--EXEC Meeting_Minutes_Master_Save_SP 'Corporate', 'Example Corp', '2023-03-20', '10:00:00';
--GO

USE MeetingLoggerDB; 
GO

-- Execute the stored procedure with parameter values
EXEC Meeting_Minutes_Master_Save_SP 
    @CustomerType = 'Corporate', 
    @CustomerName = 'Example Corp', 
    @MeetingDate = '2023-03-20', 
    @MeetingTime = '10:00:00',
    @MeetingPlace = 'Conference Room A',
    @AttendsFromClientSide = 'John Doe, Jane Smith',
    @AttendsFromHostSide = 'Host XYZ',
    @MeetingAgenda = 'Discussion on Project ABC',
    @MeetingDiscussion = 'Covered project milestones and challenges',
    @MeetingDecision = 'Resolved to allocate additional resources'
GO

EXEC Meeting_Minutes_Details_Save_SP 4, 2, 15;
GO

-- See data
USE MeetingLoggerDB;
GO

-- Select data from Corporate_Customer_Tbl
SELECT * FROM Corporate_Customer_Tbl;
GO

-- Select data from Individual_Customer_Tbl
SELECT * FROM Individual_Customer_Tbl;
GO

-- Select data from Products_Service_Tbl
SELECT * FROM Products_Service_Tbl;
GO

-- Select data from Meeting_Minutes_Master_Tbl
SELECT * FROM Meeting_Minutes_Master_Tbl;
GO

-- Select data from Meeting_Minutes_Details_Tbl
SELECT * FROM Meeting_Minutes_Details_Tbl;
GO