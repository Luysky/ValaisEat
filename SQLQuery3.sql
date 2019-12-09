

CREATE TABLE [OrderDish]
(
 [Quantity]       int NOT NULL ,
 [OrderDishPrice] money NOT NULL ,
 [IdDish]         int NOT NULL ,
 [IdOrder]        int NOT NULL ,


 CONSTRAINT [FK_118] FOREIGN KEY ([IdDish])  REFERENCES [Dish]([IdDish]),
 CONSTRAINT [FK_121] FOREIGN KEY ([IdOrder])  REFERENCES [Order]([IdOrder])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_118] ON [OrderDish] 
 (
  [IdDish] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_121] ON [OrderDish] 
 (
  [IdOrder] ASC
 )

GO







