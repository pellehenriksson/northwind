
delete from Orderlines
delete from orders
delete from Employees
delete from Customers
delete from Shippers
delete from Products
delete from Suppliers
delete from Categories
delete from Territories
delete from Regions

----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Employees ON

	insert into Employees (Id, Name, Title, DayOfBirth, HiredDate, Notes, ReportsTo_id, AddressStreet, AddressPostalCode, AddressCity, AddressRegion, AddressCountry)
	select EmployeeID, FirstName + ' ' + LastName, Title, BirthDate, HireDate, Notes, ReportsTo, Address, PostalCode, City, Region, Country  from Northwind.dbo.Employees

SET IDENTITY_INSERT Employees OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Regions ON

	insert into Regions (Id, Name )
	select RegionId, RegionDescription from Northwind.dbo.Region

SET IDENTITY_INSERT Regions OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Territories ON

	insert into Territories (Id, Name, Region_id)
	select TerritoryID, TerritoryDescription, RegionID from Northwind.dbo.Territories

SET IDENTITY_INSERT Territories OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Categories ON

	insert into Categories (Id, Name, Description)
	select CategoryID, CategoryName, Description from Northwind.dbo.Categories
	
SET IDENTITY_INSERT Categories OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Suppliers ON
	
	insert into Suppliers (Id, Name, PhonenumberNumber, PhonenumberDescription, AddressStreet, AddressPostalCode, AddressCity, AddressRegion, AddressCountry)
	select SupplierID, CompanyName, Phone, 'dispatcher', Address, PostalCode, City, Region, Country from Northwind.dbo.Suppliers
	
SET IDENTITY_INSERT Suppliers OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Products ON
	
	insert into Products (Id, Name, InStock, ReorderLevel, Discontinued, Category_id, Supplier_id, PriceAmount, PriceCurrency)
	select ProductID, ProductName, UnitsInStock, ReorderLevel, Discontinued, CategoryID, SupplierID, UnitPrice, 'USD' from Northwind.dbo.Products
	
SET IDENTITY_INSERT Products OFF
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Shippers ON

	insert into Shippers (Id, Name, PhonenumberNumber, PhonenumberDescription)
	select ShipperID, CompanyName, Phone, 'dispatcher' from Northwind.dbo.Shippers
	
SET IDENTITY_INSERT Shippers OFF
----------------------------------------------------------------------------------------------------

	insert into Customers (TraceId, Name, Contact, AddressStreet, AddressPostalCode, AddressCity, AddressRegion, AddressCountry)
	select CustomerID, CompanyName, ContactName, Address, PostalCode, City, Region, Country from Northwind.dbo.Customers
	
----------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT Orders ON

	insert into Orders(Id, OrderDate, Customer_id, Employee_Id)
	select OrderID, OrderDate, Customers.Id, EmployeeID from Northwind.dbo.Orders
		inner join Customers on Customers.TraceId = Northwind.dbo.Orders.CustomerID

SET IDENTITY_INSERT Orders OFF
----------------------------------------------------------------------------------------------------
	
	insert into OrderLines (Product_id, UnitPriceAmount, UnitPriceCurrency, QuantityValue, Order_id)
	select ProductID, UnitPrice, 'USD', Quantity, OrderID  from Northwind.dbo.[Order Details]

