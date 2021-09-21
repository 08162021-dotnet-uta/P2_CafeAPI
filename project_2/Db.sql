CREATE DATABASE Demo_08162021batch3;

USE Demo_08162021batch3
go
--USE StoreApplicationDB
--go

--create an insert statement for one product
CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
ProductName nvarchar(50) NOT NULL,
ProductDescription nvarchar(100) NOT NULL,
ProductPrice decimal(19,4) NOT NULL,
ProductPicture nvarchar(100) NOT NULL,
ProductQuantity INT NOT NULL);


--create an insert statement for one customer
CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Email nvarchar(50) NOT NULL,
PasswordH nvarchar(40));

--create
CREATE TABLE Stores(
StoreId INT PRIMARY KEY IDENTITY,
StoreName nvarchar(50) NOT NULL);

CREATE TABLE StoresProduct(
StoreProductId INT PRIMARY KEY IDENTITY,
StoreguidId uniqueidentifier NOT NULL,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE);

-- be ready to create an order with at least
CREATE TABLE ItemizedOrders(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
OrderId uniqueidentifier NOT NULL,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
StoreProductId INT NOT NULL FOREIGN KEY REFERENCES StoresProduct(StoreProductId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId),
OrderDate date NOT NULL);


-- I will create a view to display any particular order and it's details.

INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('SANGARIA Royal Milk Tea', 'Sangaria royal milk tea made with premium leaf and real milk (Pack of 24)', 42.90,7,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');

INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Cheese Pizza', 'A plain old pizza with only cheese as its topping', 5.99,8,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');


INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Water Filter', 'A water filter with a pitcher.', 25.00,10,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');


INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Hydroflask', 'An insulated water bottle perfect for keeping your water cold, even during a hot day.', 25.00,20,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');


INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Bicycle Cage', 'A small cage that can be attached to your bicycle to hold a water bottle.', 10.00,1,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');


INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Standing Desk', 'Rising desk that fits two monitors', 200,3,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');


INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Backpack', 'Can hold stuff for you.', 65.99,2,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');

INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Pillow', 'Satin Pillow', 24.99,4,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');

INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice,ProductQuantity,ProductPicture)
VALUES ('Shea Moisture Conditioner', 'Deep Conditioner',11.99,10,'C:\Users\joshu\OneDrive\Desktop\School\Pictures\1.jpg');




INSERT INTO dbo.Customers (FirstName, LastName,Email,PasswordH)
VALUES ('Yami', 'Sukehiro','tori@gmail.com','SuperSecret1');

INSERT INTO Customers
 (LastName,FirstName,Email,PasswordH)
VALUES ('Bond','JamesBond','JamesBond@double0seven.com', 'License2Ki!!' );

INSERT INTO Customers(FirstName, LastName,Email,PasswordH)
Values('Austin', 'Towler','AustinTowler@double0seven.com', 'Austin2Powers');


INSERT INTO dbo.Stores(StoreName)
VALUES('Amazon');

INSERT INTO dbo.Stores(StoreName)
VALUES('WonderBrianna?');

INSERT INTO dbo.Stores(StoreName)
VALUES('AKill2Birds1Stone');


INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES('2f473542-41c7-4f87-a5b3-717afe821305',1,1);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES('2f473542-41c7-4f87-a5b3-717afe821305',1,2);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES('2f473542-41c7-4f87-a5b3-717afe821305',1,3);


--
INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 2, 4);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 2, 5);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('74063857-e94e-4f3f-b365-f49c1b2121a6', 2, 6);


INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('99e27569-dbb1-448a-abce-8e84688eac50', 3, 7);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('99e27569-dbb1-448a-abce-8e84688eac50', 3, 8);

INSERT INTO dbo.StoresProduct(StoreguidId,StoreId,ProductId)
VALUES ('99e27569-dbb1-448a-abce-8e84688eac50', 3, 9);


SELECT * FROM dbo.Products

SELECT * FROM Customers
DELETE FROM Customers
--WHERE CustomerId>5

SELECT * FROM Stores

SELECT * FROM StoresProduct
--SELECT StoreId FROM StoresProduct Where StoreguidId = '4861525C-D270-45CA-BED3-DA8A97592D42'

SELECT * FROM dbo.ItemizedOrders


--UPDATE Products
--SET ProductQuantity = 1
--WHERE ProductId = 5

--Delete from StoresProduct where StoreProductId>92


--Select ProductName from Products
--Join StoresProduct
--on Products.ProductId = StoresProduct.ProductId
--WHERE StoreId=2
--Join ItemizedOrders
--on ItemizedOrders.ProductId = StoresProduct.ProductId
--WHERE StoresProduct.StoreId=2

--WHERE ItemizedOrders.

INSERT INTO dbo.ItemizedOrders(OrderId,CustomerId,StoreProductId, ProductId, OrderDate)
VALUES('EE17E695-0A23-4ED7-9249-F75E9197F012',1,1,1,getdate());

INSERT INTO dbo.ItemizedOrders(OrderId,CustomerId,StoreProductId,ProductId, OrderDate)
VALUES('EE17E695-0A23-4ED7-9249-F75E9197F012',1,2,4,getdate());
INSERT INTO dbo.ItemizedOrders(OrderId,CustomerId,StoreProductId,ProductId, OrderDate)
VALUES('EE17E695-0A23-4ED7-9249-F75E9197F012',1,3,7,getdate());


