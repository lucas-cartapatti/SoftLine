create database SoftLineDB
go

use SoftLineDB


if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Authentic')
begin

	create table Authentic
	(
		[Id]				int primary key identity(1,1)
		, [Username]		varchar(50) not null
		, [Password]		varchar(150) not null
		, [Email]			varchar(100) not null
		, [Active]			bit not null
		, [DateCreation]	datetime2

		, CONSTRAINT UNIQ_AUTHENTIC_USER UNIQUE(Username)
		, CONSTRAINT UNIQ_AUTHENTIC_MAIL UNIQUE(Email)
	)

end
go


if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Product')
begin

	create table Product
	(
		[Id]			int primary key identity(1,1)
		, [Description] varchar(150) not null
		, [Code]		varchar(25)  not null
		, [Price]		decimal(18,2) not null
		, [GrossWeight]	decimal(18,3) not null
		, [NetWeight]	decimal(18,3) not null

		, CONSTRAINT UNIQ_PRODUCT_CODE UNIQUE(Code)
	)

end
go

if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Customer')
begin

	create table Customer
	(
		[Id]			int primary key identity(1,1)
		, [CompanyName] varchar(150) not null
		, [TradeName]	varchar(25)  not null
		, [Document]	varchar(20) not null
		, [Location]	varchar(300) not null
		, [Active]		bit not null

		, CONSTRAINT UNIQ_CUSTOMER_DOCUMENT UNIQUE(Document)
	)
end
go