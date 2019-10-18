/* Crear Cliente*/
USE [HornosDB]
GO
INSERT INTO [dbo].[clients]([cedula_cliente],[primer_nombre_cliente],[segundo_nombre_cliente],[primer_apellido_cliente],[segundo_apellido_cliente],[correo_electronico_cliente],[estado_cliente])
     VALUES ('5-5544-4455','Carlos','Andres','Camacho','Herrera','achfc@gmail.com','Activo')
GO

/* sp_AnalyticsEarnings*/
USE [HornosDB]
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[sp_AnalyticsEarnings]
		@Ano_Mes = N'2019-10',
		@mes_existe = 1
SELECT	'Return Value' = @return_value
GO

USE [HornosDB]
GO

/* [sp_SQL_Mostrar_Factura] */

DECLARE	@return_value int
EXEC	@return_value = [dbo].[sp_SQL_Mostrar_Factura]
		@compraID = 9	-- Numero de Factura
SELECT	'Return Value' = @return_value
GO
