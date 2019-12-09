
CREATE TABLE [Area]
(
 [IdArea]    int NOT NULL ,
 [IdCountry] int NOT NULL ,
 [Name]      varchar(50) NOT NULL ,


 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([IdArea] ASC),
 CONSTRAINT [FK_11] FOREIGN KEY ([IdCountry])  REFERENCES [Country]([IdCountry])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_11] ON [Area] 
 (
  [IdCountry] ASC
 )

GO




CREATE TABLE [City]
(
 [IdCity] int NOT NULL ,
 [IdArea] int NOT NULL ,
 [Name]   varchar(50) NOT NULL ,
 [Npa]    int NOT NULL ,


 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([IdCity] ASC),
 CONSTRAINT [FK_20] FOREIGN KEY ([IdArea])  REFERENCES [Area]([IdArea])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_20] ON [City] 
 (
  [IdArea] ASC
 )

GO


CREATE TABLE [Country]
(
 [IdCountry] int NOT NULL ,
 [Name]      varchar(50) NOT NULL ,


 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([IdCountry] ASC)
);
GO




CREATE TABLE [Customer]
(
 [IdCustomer] int NOT NULL ,
 [IdCity]     int NOT NULL ,
 [Name]       varchar(50) NOT NULL ,
 [Adresse]    varchar(50) NOT NULL ,
 [Email]      varchar(50) NOT NULL ,
 [Password]   varchar(50) NOT NULL ,


 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([IdCustomer] ASC),
 CONSTRAINT [FK_40] FOREIGN KEY ([IdCity])  REFERENCES [City]([IdCity])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_40] ON [Customer] 
 (
  [IdCity] ASC
 )

GO




CREATE TABLE [Deliver]
(
 [IdDeliver]   int NOT NULL ,
 [IdArea]      int NOT NULL ,
 [Name]        varchar(50) NOT NULL ,
 [PhoneNumber] varchar(50) NOT NULL ,


 CONSTRAINT [PK_Deliver] PRIMARY KEY CLUSTERED ([IdDeliver] ASC),
 CONSTRAINT [FK_50] FOREIGN KEY ([IdArea])  REFERENCES [Area]([IdArea])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_50] ON [Deliver] 
 (
  [IdArea] ASC
 )

GO




CREATE TABLE [Dish]
(
 [IdDish]       int NOT NULL ,
 [IdRestaurant] int NOT NULL ,
 [Name]         varchar(50) NOT NULL ,
 [DishPrice]    money NOT NULL ,
 [Status]       varchar(50) NOT NULL ,


 CONSTRAINT [PK_Dishes] PRIMARY KEY CLUSTERED ([IdDish] ASC),
 CONSTRAINT [FK_60] FOREIGN KEY ([IdRestaurant])  REFERENCES [Restaurant]([IdRestaurant])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_60] ON [Dish] 
 (
  [IdRestaurant] ASC
 )

GO



CREATE TABLE [Order]
(
 [IdOrder]    int NOT NULL ,
 [IdDeliver]  int NOT NULL ,
 [IdCustomer] int NOT NULL ,
 [Status]     varchar(50) NOT NULL ,
 [OrderPrice] money NOT NULL ,


 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([IdOrder] ASC),
 CONSTRAINT [FK_69] FOREIGN KEY ([IdDeliver])  REFERENCES [Deliver]([IdDeliver]),
 CONSTRAINT [FK_74] FOREIGN KEY ([IdCustomer])  REFERENCES [Customer]([IdCustomer])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_69] ON [Order] 
 (
  [IdDeliver] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_74] ON [Order] 
 (
  [IdCustomer] ASC
 )

GO




CREATE TABLE [OrderDish]
(
 [IdOrder]        int NOT NULL ,
 [IdDish]         int NOT NULL ,
 [Quantity]       int NOT NULL ,
 [OrderDishPrice] money NOT NULL ,


 CONSTRAINT [PK_OrderDish] PRIMARY KEY CLUSTERED([IdOrder,IdDish]),
 CONSTRAINT [FK_84] FOREIGN KEY ([IdOrder])  REFERENCES [Order]([IdOrder]),
 CONSTRAINT [FK_89] FOREIGN KEY ([IdDish])  REFERENCES [Dish]([IdDish])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_84] ON [OrderDish] 
 (
  [IdOrder] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_89] ON [OrderDish] 
 (
  [IdDish] ASC
 )

GO


CREATE TABLE [Restaurant]
(
 [IdRestaurant] int NOT NULL ,
 [IdCity]       int NOT NULL ,
 [Name]         varchar(50) NOT NULL ,


 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED ([IdRestaurant] ASC),
 CONSTRAINT [FK_28] FOREIGN KEY ([IdCity])  REFERENCES [City]([IdCity])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_28] ON [Restaurant] 
 (
  [IdCity] ASC
 )

GO

































