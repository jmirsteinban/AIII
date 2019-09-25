create procedure [dbo].[sp_directions_clients]
@clientID int
AS
BEGIN
	select direccion from [dbo].[directions] where relacionID=@clientID and tabla_relacion='clients';
END;

create procedure [dbo].[sp_directions_users]
@userID int
AS
BEGIN
	select direccion from [dbo].[directions] where relacionID=@userID and tabla_relacion='users';
END;

create procedure [dbo].[sp_phones_clients]
@clientID int
AS
BEGIN
	select telefono from [dbo].[phones] where relacionID=@clientID and tabla_relacion='clients';
END;

create procedure [dbo].[sp_phones_users]
@userID int
AS
BEGIN
	select telefono from [dbo].[phones] where relacionID=@userID and tabla_relacion='users';
END;
