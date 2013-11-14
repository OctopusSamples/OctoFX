-- Populate the exchange rate columns with initial seed values. The Rate service will 
-- update the rates based on the market.

insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('GBP/AUD', 1.7217)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('EUR/AUD', 1.4464)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('USD/AUD', 1.0749)

insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('AUD/GBP', 0.5806)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('EUR/GBP', 0.8396)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('USD/GBP', 0.6246)

insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('AUD/EUR', 0.6916)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('GBP/EUR', 1.1912)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('USD/EUR', 0.7440)

insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('AUD/USD', 0.9296)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('GBP/USD', 1.6011)
insert into dbo.[ExchangeRate](SellBuyCurrencyPair, Rate) values ('EUR/USD', 1.3442)

go
