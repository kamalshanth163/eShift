CREATE TABLE Customers (
    CustomerNumber NVARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

CREATE TABLE Admins (
    AdminId NVARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

CREATE TABLE Products (
    ProductCode NVARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(200),
    HandlingFee DECIMAL(10, 2) NOT NULL
);

CREATE TABLE TransportUnits (
    TransportUnitId NVARCHAR(20) PRIMARY KEY,
    LorryNumber NVARCHAR(50) NOT NULL,
    DriverName NVARCHAR(100) NOT NULL,
    DriverLicense NVARCHAR(50) NOT NULL,
    AssistantName NVARCHAR(100) NOT NULL,
    ContainerNumber NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL
);

CREATE TABLE Jobs (
    JobNumber NVARCHAR(20) PRIMARY KEY,
    CustomerNumber NVARCHAR(20) NOT NULL,
    RequestDate DATETIME NOT NULL,
    StartLocation NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    AdminRemarks NVARCHAR(200),
    TotalFee DECIMAL(10, 2),
    FOREIGN KEY (CustomerNumber) REFERENCES Customers(CustomerNumber)
);

CREATE TABLE Loads (
    LoadNumber NVARCHAR(20) PRIMARY KEY,
    JobNumber NVARCHAR(20) NOT NULL,
    ProductCode NVARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    Weight DECIMAL(10, 2) NOT NULL,
    SpecialInstructions NVARCHAR(200),
    TransportUnitId NVARCHAR(20),
    FOREIGN KEY (JobNumber) REFERENCES Jobs(JobNumber),
    FOREIGN KEY (ProductCode) REFERENCES Products(ProductCode),
    FOREIGN KEY (TransportUnitId) REFERENCES TransportUnits(TransportUnitId)
);

-- Insert initial admin account
INSERT INTO Admins (AdminId, Name, Username, Password) 
VALUES ('ADMIN001', 'System Admin', 'admin', 'admin123');