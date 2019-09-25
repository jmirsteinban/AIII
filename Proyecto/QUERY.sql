CREATE DATABASE HornosDB;

USE HornosDB
GO

CREATE TABLE [dbo].[users] (
userID INT PRIMARY KEY IDENTITY(1,1),
cedula_user VARCHAR(25) not null UNIQUE,
CONSTRAINT chkCedula_user check (cedula_user like '[0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
primer_nombre_user VARCHAR(80) not null,
segundo_nombre_user VARCHAR(60) null,
primer_apellido_user VARCHAR(80) not null,
segundo_apellido_user VARCHAR(80) not null,
usuario VARCHAR(20) not null UNIQUE,
contrasena VARCHAR(200) not null,
tipo_user VARCHAR(10) not null,
CONSTRAINT chkTipo_user check (tipo_user in ('Admin','Empleado')),
estado_user VARCHAR(20) not null
CONSTRAINT chkEstado_user check (estado_user in ('Activo','Inhabilitado'))
);

CREATE TABLE [dbo].[clients](
clientID INT PRIMARY KEY IDENTITY(1,1),
cedula_cliente VARCHAR(25) not null UNIQUE,
CONSTRAINT chkCedula_cliente check (cedula_cliente like '[0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
primer_nombre_cliente VARCHAR(80) not null,
segundo_nombre_cliente VARCHAR(60) null,
primer_apellido_cliente VARCHAR(80) not null,
segundo_apellido_cliente VARCHAR(80) not null,
correo_electronico_cliente VARCHAR(100) null UNIQUE,
CONSTRAINT chkCorreo CHECK (correo_electronico_cliente like '%@%'),
estado_cliente VARCHAR(20) not null,
CONSTRAINT chkEstado_cliente check (estado_cliente in ('Activo','Inhabilitado'))
);

CREATE TABLE [dbo].[phones](
telefonoID INT PRIMARY KEY IDENTITY(1,1),
relacionID INT not null,
tabla_relacion VARCHAR(20) not null,
telefono VARCHAR(10) not null UNIQUE,
CONSTRAINT chkTelefono CHECK (Telefono like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')
);

CREATE TABLE [dbo].[directions](
direccionID INT PRIMARY KEY IDENTITY(1,1),
relacionID INT not null,
tabla_relacion VARCHAR(20) not null,
direccion VARCHAR(200) not null
);

CREATE TABLE [dbo].[products](
productID INT PRIMARY KEY IDENTITY(1,1),
codigo_producto VARCHAR(10) not null,
nombre_producto VARCHAR(100) not null UNIQUE,
descripcion VARCHAR(150) not null,
cantidad INT not null,
precio_manufactura MONEY null,
precio_venta MONEY not null,
estado_producto VARCHAR(20) not null,
CONSTRAINT chkEstado_producto check (estado_producto in ('Disponible','Agotado','Descontinuado')),
porcentaje_ganancia DECIMAL(2,2) not null,
porcentaje_descuento DECIMAL(2,2) null
);

CREATE TABLE [dbo].[sales](
compraID INT PRIMARY KEY IDENTITY(1,1),
clientID INT not null,
FOREIGN KEY (clientID) REFERENCES [dbo].[clients] (clientID),
userID INT not null,
FOREIGN KEY (userID) REFERENCES [dbo].[users] (userID),
fecha_compra DATETIME default CURRENT_TIMESTAMP,
monto_total MONEY not null,
estado_factura VARCHAR(20) not null,
CONSTRAINT chkEstado_factura check (estado_factura in('Procesando','Completado'))
);

CREATE TABLE [dbo].[sales_x_products](
compraID_detalle INT PRIMARY KEY IDENTITY(1,1),
compraID INT not null,
CONSTRAINT fkCompraID_cascade_salesProducts FOREIGN KEY (compraID) REFERENCES [dbo].[sales] (compraID) ON DELETE CASCADE,
productID INT not null,
FOREIGN KEY (productID) REFERENCES [dbo].[products] (productID),
precio_factura_d MONEY not null
);

CREATE TABLE [dbo].[warranties](
warrantyID INT PRIMARY KEY IDENTITY(1,1),
compraID INT not null,
CONSTRAINT fkCompraID_cascade_warranties FOREIGN KEY (compraID) REFERENCES [dbo].[sales] (compraID),
estado_warranty VARCHAR(20) not null,
CONSTRAINT chkEstado_warranty check (estado_warranty in('Aplicable','Vencida'))
);

CREATE TABLE [dbo].[earnings](
earningID INT PRIMARY KEY IDENTITY(1,1),
earnings_total_mes MONEY not null,
conteo_facturas int not null,
fecha_reporte DATETIME default CURRENT_TIMESTAMP
);

CREATE TABLE [dbo].[bitacora](
registroID INT PRIMARY KEY IDENTITY(1,1),
usuario VARCHAR(50) DEFAULT CURRENT_USER,
accion VARCHAR(80) not null,
fecha_hora DATETIME DEFAULT CURRENT_TIMESTAMP
);



