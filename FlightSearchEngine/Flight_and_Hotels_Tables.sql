CREATE DATABASE FlightSearchDB;

use FlightSearchDB;

Create Table Flights(
	FlightId INT PRIMARY KEY IDENTITY(1,1),
	FlightName NVARCHAR(100) NOT NULL,
	FlightType NVARCHAR(50) NOT NULL,
	Source NVARCHAR(100) NOT NULL,
	Destination NVARCHAR(100) NOT NULL,
	PricePerSeat DECIMAL(18, 2) NOT NULL
);

Create Table Hotels(
	HotelId INT PRIMARY KEY IDENTITY(1,1),
	HotelName NVARCHAR(100) NOT NULL,
	HotelType NVARCHAR(50) NOT NULL,
	Location NVARCHAR(100) NOT NULL,
	PricePerDay DECIMAL(18,2) NOT NULL
);

INSERT INTO Flights VALUES
('Indigo 101','Domestic','Delhi','Mumbai',5000),
('Air India 202','Domestic','Delhi','Chennai',6000),
('Emirates 303','International','Delhi','Dubai',20000);

INSERT INTO Hotels VALUES
('Taj Mumbai','5 Star','Mumbai',8000),
('ITC Chennai','5 Star','Chennai',7000),
('Atlantis Dubai','Luxury','Dubai',15000);

----------------------------------------------------
CREATE PROCEDURE sp_GetSources
AS
BEGIN
	Select DISTINCT Source from Flights;

END

-----------------------------------------------------
CREATE PROCEDURE sp_GetDestination
AS
BEGIN
	Select DISTINCT Destination from Flights;

END

-----------------------------------------------------
CREATE PROC sp_SearchFlights
	@Source NVARCHAR(100),
	@Destination NVARCHAR(100),
	@Persons INT 
AS
BEGIN
		Select *, (PricePerSeat * @Persons) AS TotalCost from Flights Where Source = @Source and Destination = @Destination;

END

----------------------------------------------------------
CREATE PROC sp_SearchFlightsWithHotels
	@Source NVARCHAR(100),
	@Destination NVARCHAR(100),
	@Persons INT
AS
BEGIN
	Select f.*, h.*, ((f.PricePerSeat * @Persons) + h.PricePerDay) AS TotalCost  from Flights f INNER JOIN Hotels h on f.Destination = h.Location Where f.Source = @Source and f.Destination = @Destination;
END

---------------------------------------------------------
EXEC sp_GetSources;
EXEC sp_GetDestination;
EXEC sp_SearchFlights @Source = 'Delhi', @Destination = 'Mumbai', @Persons = 2;
EXEC sp_SearchFlightsWithHotels @Source = 'Delhi', @Destination = 'Mumbai', @Persons = 2;

