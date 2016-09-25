use master
go

create database Warehouse;
go

use Warehouse;
go

create table Customer(
	 CustomerId uniqueidentifier primary key
	,Title nvarchar(250) not null
	,Phone nvarchar(50)
	,Website nvarchar(50) 
) 

create table Invoice(
	 InvoiceId uniqueidentifier primary key
	,CustomerId uniqueidentifier not null 
		foreign key (CustomerId) references Customer(CustomerID) 
	,Address nvarchar(500)
	,IsPaid char(1)
	,IsShiped char(1)
)

create table Ware(
     WareId uniqueidentifier primary key
    ,Title nvarchar(250)
    ,Price decimal(18,4) 
)

create table InvoceContent(
	 InvoiceId uniqueidentifier
		foreign key (InvoiceId) references Invoice(InvoiceId)
	,WareId uniqueidentifier
		foreign key (WareId) references Ware(WareId)
	,Date datetime
	,Quantity int
	,Price decimal(12,4)
	
	constraint pk_InvoceContent primary key (InvoiceId, WareId)
)

go 

insert into Customer values(newid(), 'ACME', '555-23-12', 'acme.com')
insert into Customer values(newid(), 'Google', '555-45-34', 'google.com')
insert into Customer values(newid(), 'MS', '777-43-23', 'ms.com')
insert into Customer values(newid(), 'IBM', '777-88-00', 'ibm.com')
insert into Customer values(newid(), 'htc', '999-12-12', 'htc.com')

insert into Ware values(newid(), 'Bomb', 100000)
insert into Ware values(newid(), 'Napkin', 2)
insert into Ware values(newid(), 'Case', 10)
insert into Ware values(newid(), 'Water', 5)
insert into Ware values(newid(), 'Processor', 23)