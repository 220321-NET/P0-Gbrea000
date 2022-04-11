CREATE TABLE Stores 
(
    StoreID INT PRIMARY Key IDENTITY (1,1),
    City VARCHAR(30) Not null,
);

INSERT INTO Stores(City) VALUES
('Lancaster')
INSERT INTO Stores(City) VALUES
('Boston')
INSERT INTO Stores(City) VALUES
('Orlando')

SELECT * FROM Stores;

Drop Table Stores
-------------------------------------------------------------------
CREATE TABLE Customers
(
    Customerid INT PRIMARY Key IDENTITY (1,1),
    Username VARCHAR (50) not null UNIQUE,
    Password VARCHAR (50),
)

INSERT Into Customers(Username, PASSWORD) VALUES
('PlantLover', 'P@ssw0rd')

SELECT * FROM Customers;

Drop Table Customers
------------------------------------------------------------------
CREATE TABLE Stock
(
    StockId INT PRIMARY Key IDENTITY (1,1),
    ProductID INT FOREIGN Key REFERENCES Products(ProductID),
    StoreID INT NOT NULL FOREIGN Key REFERENCES Stores(StoreID) On DELETE CASCADE,
    quantity INT NOT null,
)

INSERT INTO STOCK VALUES(1, 1, 10)
INSERT INTO STOCK VALUES(2, 1, 8)
INSERT INTO STOCK VALUES(3, 1, 15)
INSERT INTO STOCK VALUES(1, 2, 5)
INSERT INTO STOCK VALUES(2, 2, 10)
INSERT INTO STOCK VALUES(3, 2, 15)
SELECT * FROM Stock

Drop Table Stock
----------------------------------------------------------------
CREATE TABLE Products
(
    ProductID INT PRIMARY Key IDENTITY (1,1),
    ProductName VARCHAR(50) Not null,
    Cost FLOAT NOT NULL,
)

INSERT INTO Products(Name, Cost) Values(
'Monstera', $29.98
)
INSERT INTO Products(Name, Cost) Values(
'Alocasia', $39.98
)
INSERT INTO Products(Name, Cost) Values(
'Ficus', $49.98
)

SELECT * From Products;

Drop Table Products
-------------------------------------------------------------------
CREATE TABLE Cart
(
    CartID INT PRIMARY Key IDENTITY (1,1),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(Orderid)
)

SELECT * From Cart;

Drop Table Cart
---------------------------------------------------------------------
CREATE TABLE Orders
(
    OrderID INT PRIMARY Key IDENTITY (1,1),
    DateCreated DATETIME NULL,
    OrderNUM INT NOT NULL, 
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    StoreID INT NOT NULL FOREIGN Key REFERENCES Stores(StoreID),
    CustomerID INT NOT NULL FOREIGN Key REFERENCES Customers(CustomerID) ON DELETE CASCADE,
    Total FLOAT,
)

Select * From Orders

DROP TABLE Orders
---------------------------------------------------
SELECT * FROM Customers;
