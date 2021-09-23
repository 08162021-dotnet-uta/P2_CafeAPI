--create Customers table
CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL);

-- create Administrator table
CREATE TABLE Administrator(
AdministratorId INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
EmailAddress varchar(50) NOT NULL,
Role varchar(50));

-- create SingIn table
CREATE TABLE SignIn(
UserName varchar(30) NOT NULL,
Password varchar(30) NOT NULL,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
AdministratorId INT NOT NULL FOREIGN KEY REFERENCES Administrator(AdministratorId) ON DELETE CASCADE)

-- create Products table
CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
ProductName varchar(50) NOT NULL,
ProductDescription varchar(100) NOT NULL,
Price decimal(20,4) NOT NULL,
Inventory INT NOT NULL);

-- create Order table
CREATE TABLE [Order](
OrderId INT PRIMARY KEY IDENTITY,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
NumberOfItems INT NOT NULL,
TotalPrice decimal(20,4) NOT NULL);