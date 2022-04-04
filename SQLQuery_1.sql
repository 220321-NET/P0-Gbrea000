CREATE TABLE Stores 
(
    StoreID INT PRIMARY Key IDENTITY (1,1),
    City VARCHAR(30),
);

INSERT INTO Stores(City) VALUES
('Lancaster')

SELECT * FROM Stores;

CREATE TABLE Customers
(
    CustomerID INT PRIMARY Key IDENTITY (1,1),
    Username VARCHAR (30) not null UNIQUE,
    Password VARCHAR (100),
)

INSERT Into Customers(Username, PASSWORD) VALUES
('PlantLover', 'P@ssw0rd')

SELECT * FROM Customers;

CREATE TABLE Inventory
(
    StoreID INT PRIMARY Key IDENTITY (1,1) REFERENCES Stores(StoreID),
    ProductID INT,
    Quantity INT,
)

INSERT INTO Inventory(StoreID, ProductID, Quantity) VALUES
('1', 'Monstera', '10');

SELECT * FROM Inventory;
--
CREATE TABLE Product
(
    ProductID INT PRIMARY Key IDENTITY (1,1),
    Name VARCHAR(50),
    Cost INT,
)

SELECT * From Product;

CREATE TABLE Cart
(
    CartID INT PRIMARY Key IDENTITY (1,1),
    ProductID VARCHAR(50) FOREIGN Key REFERENCES Product(ProductID),
    Cost INT,
)

SELECT * From Cart;

CREATE TABLE Orders
(
    OrderID INT PRIMARY Key IDENTITY (1,1),
    StoreID INT FOREIGN Key REFERENCES Stores(StoreID),
    CartID INT FOREIGN Key REFERENCES Cart(CartID),
    CustomerID INT FOREIGN Key REFERENCES Customers(CustomerID),
    Total INT,
)

Select * From Orders