CREATE TRIGGER trg_bitacora_after_insert_clients
ON [dbo].[clients] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Clientes',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_clients ON [dbo].[clients]
GO

CREATE TRIGGER trg_bitacora_after_insert_directions
ON [dbo].[directions] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Directions',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_directions ON [dbo].[directions]
GO

CREATE TRIGGER trg_bitacora_after_insert_earnings
ON [dbo].[earnings] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Earnings',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_earnings ON [dbo].[earnings]
GO

CREATE TRIGGER trg_bitacora_after_insert_phones
ON [dbo].[phones] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Phones',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_phones ON [dbo].[phones]
GO

CREATE TRIGGER trg_bitacora_after_insert_products
ON [dbo].[products] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Products',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_products ON [dbo].[products]
GO

CREATE TRIGGER trg_bitacora_after_insert_sales
ON [dbo].[sales] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Sales',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_sales ON [dbo].[sales]
GO

CREATE TRIGGER trg_bitacora_after_insert_sales_x_products
ON [dbo].[sales_x_products] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Sales_x_Products',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_sales_x_products ON [dbo].[sales_x_products]
GO

CREATE TRIGGER trg_bitacora_after_insert_users
ON [dbo].[users] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Users',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_users ON [dbo].[users]
GO

CREATE TRIGGER trg_bitacora_after_insert_warranties
ON [dbo].[warranties] AFTER INSERT
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Insert en la tabla Warranties',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_insert_warranties ON [dbo].[warranties]
GO

--DELETES
--DELETES
--DELETES

CREATE TRIGGER trg_bitacora_after_delete_clients
ON [dbo].[clients] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Delete en la tabla Clientes',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_clients ON [dbo].[clients]
GO

CREATE TRIGGER trg_bitacora_after_delete_earnings
ON [dbo].[earnings] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values (Current_user,'Delete en la tabla Earnings',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_earnings ON [dbo].[earnings]
GO

CREATE TRIGGER trg_bitacora_after_delete_sales
ON [dbo].[sales] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values (Current_user,'Delete en la tabla Sales',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_sales ON [dbo].[sales]
GO

CREATE TRIGGER trg_bitacora_after_delete_sales_x_products
ON [dbo].[sales_x_products] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values (Current_user,'Delete en la tabla Sales_x_Products',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_sales_x_products ON [dbo].[sales_x_products]
GO

CREATE TRIGGER trg_bitacora_after_delete_users
ON [dbo].[users] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Delete en la tabla Users',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_users ON [dbo].[users]
GO

CREATE TRIGGER trg_bitacora_after_delete_warranties
ON [dbo].[warranties] AFTER DELETE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Delete en la tabla Warranties',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_delete_warranties ON [dbo].[warranties]
GO

--UPDATES
--UPDATES
--UPDATES

CREATE TRIGGER trg_bitacora_after_update_directions
ON [dbo].[directions] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Directions',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_directions ON [dbo].[directions]
GO

CREATE TRIGGER trg_bitacora_after_update_earnings
ON [dbo].[earnings] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Earnings',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_earnings ON [dbo].[earnings]
GO

CREATE TRIGGER trg_bitacora_after_update_phones
ON [dbo].[phones] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Phones',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_phones ON [dbo].[phones]
GO

CREATE TRIGGER trg_bitacora_after_update_products
ON [dbo].[products] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Products',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_products ON [dbo].[products]
GO

CREATE TRIGGER trg_bitacora_after_update_sales
ON [dbo].[sales] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Sales',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_sales ON [dbo].[sales]
GO

CREATE TRIGGER trg_bitacora_after_update_users
ON [dbo].[users] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Users',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_users ON [dbo].[users]
GO

CREATE TRIGGER trg_bitacora_after_update_warranties
ON [dbo].[warranties] AFTER UPDATE
AS 
Begin
	insert into [dbo].[bitacora] (usuario,accion,fecha_hora) values  (Current_user,'Update en la tabla Warranties',GetDate());
END;

ENABLE TRIGGER trg_bitacora_after_update_warranties ON [dbo].[warranties]
GO