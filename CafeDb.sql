--create Customers table
CREATE TABLE Customer(
Id INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL);

-- create Administrator table
CREATE TABLE Administrator(
Id INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
EmailAddress varchar(50) NOT NULL,
[Role] varchar(50));

-- create SingIn table
CREATE TABLE SignIn(
Id INT PRIMARY KEY IDENTITY,
UserName varchar(30) NOT NULL,
[Password] varchar(30) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customer(Id) ON DELETE CASCADE,
AdministratorId INT FOREIGN KEY REFERENCES Administrator(Id) ON DELETE CASCADE)

-- create Products table
CREATE TABLE Product(
Id varchar(20) PRIMARY KEY ,
[Name] varchar(50) NOT NULL,
[Description] varchar(100),
Price decimal(20,4) NOT NULL,
Inventory INT default 10);

-- create Order table
CREATE TABLE [Order](
Id INT PRIMARY KEY IDENTITY,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(Id) ON DELETE CASCADE,
NumberOfItems INT NOT NULL,
TotalPrice decimal(20,4) NOT NULL);

-- create OrderItem table
create table [OrderItem](
Id INT PRIMARY KEY IDENTITY,
OrderId INT NOT NULL FOREIGN KEY REFERENCES [Order](Id) ON DELETE CASCADE,
ProductId varchar(20) NOT NULL FOREIGN KEY REFERENCES Product(Id) ON DELETE CASCADE
)