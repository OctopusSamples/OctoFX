create table dbo.[Account]
(
	Id int identity(1,1) not null constraint PK_Customer_Id primary key clustered,
	Email nvarchar(255) not null constraint UQ_Customer_Email unique,
	Name nvarchar(255) not null,
	PasswordHashed nvarchar(255) not null,
	IsActive bit not null
)
go

create table dbo.[BeneficiaryAccount]
(
	Id int identity(1,1) not null constraint PK_BeneficiaryAccount_Id primary key clustered,
	Nickname nvarchar(100) not null,
	AccountNumber varchar(50) not null,
	SwiftBicBsb varchar(50) not null,
	Currency varchar(3) not null,
	Country varchar(3) not null,
	IsActive bit not null
)
go

create table dbo.[Quote]
(
	Id int identity(1,1) not null constraint PK_Quote_Id primary key clustered,
	SellBuyCurrencyPair varchar(7) not null,
	Rate decimal(20,9) not null,
	SellAmount decimal(20,9) not null,
	BuyAmount decimal(20,9) not null,
	QuotedDate datetimeoffset not null,
	ExpiryDate datetimeoffset not null
)
go

create table dbo.[ExchangeRate]
(
	SellBuyCurrencyPair varchar(7) not null constraint PK_ExchangeRate_Id primary key clustered,
	Rate decimal(20,9) not null
)
go

create table dbo.[Deal]
(
	Id int identity(1,1) not null constraint PK_Deal_Id primary key clustered,
	AccountId int not null constraint FK_Deal_AccountId foreign key references dbo.[Account](Id),
	BuyCurrency varchar(3) not null,
	SellCurrency varchar(3) not null,
	BuyAmount decimal(20,9) not null,
	SellAmount decimal(20,9) not null,
	[Status] varchar(10) not null,
	EnteredDate datetimeoffset not null
)
go

