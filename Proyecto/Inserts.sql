use HornosDB
GO

/*TBL clients*/	
select * from clients;
insert into clients (cedula_cliente,primer_nombre_cliente,segundo_nombre_cliente,primer_apellido_cliente,segundo_apellido_cliente,
correo_electronico_cliente,estado_cliente) values ('1-1747-0663','Lener','Steven','Herra','Ramírez','slherra99@gmail.com','Activo');
insert into clients (cedula_cliente,primer_nombre_cliente,segundo_nombre_cliente,primer_apellido_cliente,segundo_apellido_cliente,
correo_electronico_cliente,estado_cliente) values ('1-1035-0344','Lener','','Herra','Navarro','lherra@bncr.com','Inhabilitado');
insert into clients (cedula_cliente,primer_nombre_cliente,segundo_nombre_cliente,primer_apellido_cliente,segundo_apellido_cliente,
correo_electronico_cliente,estado_cliente) values ('1-1039-0679','Katty','','Ramírez','Hernández','kramirez@gmail.com','Inhabilitado');
insert into clients (cedula_cliente,primer_nombre_cliente,segundo_nombre_cliente,primer_apellido_cliente,segundo_apellido_cliente,
correo_electronico_cliente,estado_cliente) values ('1-1044-0719','Paula','Sofía','Herra','Ramírez','pramirez@gmail.com','Inhabilitado');

/*TBL directions*/	
select * from directions;
insert into directions (relacionID,tabla_relacion,direccion) values (1,'clients','San Francisco de Heredia');
insert into directions (relacionID,tabla_relacion,direccion) values (2,'clients','San Francisco de Heredia');
insert into directions (relacionID,tabla_relacion,direccion) values (3,'clients','San Francisco de Heredia');
insert into directions (relacionID,tabla_relacion,direccion) values (4,'clients','San Francisco de Heredia');

/*TBL Phones*/	
select * from phones;
insert into phones (relacionID,tabla_relacion,telefono) values (1,'clients','8628-8436');
insert into phones (relacionID,tabla_relacion,telefono) values (2,'clients','8374-5654');
insert into phones (relacionID,tabla_relacion,telefono) values (3,'clients','8712-1415');
insert into phones (relacionID,tabla_relacion,telefono) values (4,'clients','8324-1674');

/*TBL Products*/	
select * from products;
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HT5E','Horno turbo aire Digital de 5 bandejas 45x65 electrico 220v','Horno turbo aire Digital de 
5 bandejas 45x65 electrico 220v',4,1100000,1650000,'Disponible',0.33,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HN5G','Horno turbo aire Digital de 5 bandejas 45x65 GAS','Horno turbo aire Digital de 
5 bandejas 45x65 GAS',4,1600000,2100000,'Disponible',0.24,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTP10E','Horno turbo de 10 bandejas 30x70 eléctrico 220v','Horno turbo de 10 
bandejas 30x70 eléctrico 220v',2,1600000,2200000,'Disponible',0.25,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTP10G','Horno turbo de 10 bandejas 30x70 gas','Horno turbo de 10 bandejas 30x70 gas',
3,1700000,2300000,'Disponible',0.25,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTN9E','Horno turno de 9 bandejas 45x65 eléctrico','Horno turno de 9 bandejas 
45x65 eléctrico',1,1800000,2650000,'Agotado',0.30,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTN9G','Horno turno de 9 bandejas 45x65 gas','Horno turno de 9 bandejas 45x65 gas',
6,2100000,3100000,'Agotado',0.35,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTN10E','Horno turbo de 10 bandejas 45x65 eléctrico','Horno turbo de 10 bandejas 
45x65 eléctrico',5,2100000,2850000,'Agotado',0.24,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HTN10G','Horno turbo de 10 bandejas 45x65 gas','Horno turbo de 10 bandejas 45x65 gas',
8,2500000,3100000,'Disponible',0.24,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC1','Horno de cámara de 1 bandeja 45x65 eléctrico','Horno de cámara de 1 bandeja 45x65 
eléctrico',8,125000,250000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC2E','Horno de cámara de 2 bandejas 30x70 eléctrico','Horno de cámara de 2 bandejas 
30x70 eléctrico',3,150000,300000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC3E','Horno de cámara de 3 bandejas 30x70 eléctrico','Horno de cámara de 3 bandejas 
30x70 eléctrico',3,200000,400000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC3G','Horno de cámara de 3 bandejas 30x70 gas','Horno de cámara de 3 bandejas 30x70
 gas',11,275000,550000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC4E','Horno de cámara de 4 bandejas 30x70 eléctrico','Horno de cámara de 4 bandejas 
30x70 eléctrico',7,200000,500000,'Disponible',0.57,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC4G','Horno de cámara de 4 bandejas 30x70 gas','Horno de cámara de 4 bandejas 
30x70 gas',0,300000,650000,'Agotado',0.55,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC5E','Horno de cámara de 5 bandejas 30x70 eléctrico','Horno de cámara de 5 bandejas 30x70 
eléctrico',0,300000,600000,'Agotado',0.50,0.00);	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('HC5G','Horno de cámara de 5 bandejas 30x70 gas','Horno de cámara de 5 bandejas 30x70 gas',
5,600000,750000,'Disponible',0.23,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('AF20','Afinadora de 20QTS 220V','Afinadora de 20QTS 220V',
3,600000,1100000,'Disponible',0.43,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('AF30','Afinadora de 30QTS 220V','Afinadora de 30QTS 220V',
5,700000,1500000,'Disponible',0.55,0.00);	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BAT8','Batidora de 8 litros Spar Mixer','Batidora de 8 litros Spar Mixer',
2,100000,525000,'Disponible',0.65,0.00);	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BAT20','Batidora de 20 litros Spar Mixer','Batidora de 20 litros Spar Mixer',
8,500000,1000000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BAT30','Batidora de 30 litros Spar Mixer','Batidora de 30 litros Spar Mixer',
8,750000,1500000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BAT60','Batidora de 60 litros Spar Mixer','Batidora de 60 litros Spar Mixer',
4,1500000,2300000,'Disponible',0.60,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('LAMG','Laminadora Spar Mixer','Laminadora Spar Mixer',
4,1500000,2300000,'Disponible',0.60,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('LAMP','Laminadora Pequenña Venancio','Laminadora Pequeña Venancio',
4,400000,900000,'Disponible',0.55,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('PASG','Pasadora mesa larga motor de 3HP sellado','Pasadora mesa larga motor de 3HP sellado',
4,400000,780000,'Disponible',0.46,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('PASP','Pasadora mesa corta motor de 3HP sellado','Pasadora mesa corta motor de 3HP sellado',
2,400000,780000,'Disponible',0.46,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MANT','Mantenedor de baguette para 9 bandejas 45x65','Mantenedor de baguette para 9 
bandejas 45x65',6,300000,650000,'Disponible',0.45,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('ART','Arteza','Arteza',6,60000,150000,'Disponible',0.60,0.00);		 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BOLLV','Bolladora Venancio 35EXP','Bolladora Venancio 35EXP',6,600000,900000,
'Disponible',0.24,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BOLLGPZ','Bolladora G-PANIZ MPS 500','Bolladora G-PANIZ MPS 500',6,600000,1200000,
'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('DIV','Divisora Venancio de 30 rebanadas','Divisora Venancio de 30 rebanadas',4,200000,550000,
'Disponible',0.58,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('CMFG','Cámara en frio de 2 puertas completamente en acero inoxidable','Cámara en frio de 2 puertas completamente en acero inoxidable'
,6,800000,1300000,'Disponible',0.32,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('CMFP','Cámara en frio de 1 puerta completamente en acero inoxidable','Cámara en frio de 1 puerta completamente en acero inoxidable'
,1,800000,900000,'Disponible',0.10,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UC1.5','Urna curva en acero inoxidable de 1.50cm','Urna curva en acero inoxidable de 
1.50cm',1,500000,650000,'Disponible',0.15,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UC2','Urna curva en acero inoxidable de 2m','Urna curva en acero inoxidable de 2m',
7,500000,850000,'Disponible',0.20,0.00);	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('US1,5','Urna Samuelito en acero inoxidable de 1.50cm','Urna Samuelito en acero inoxidable de 1.50cm',
7,200000,370000,'Disponible',0.15,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('US2','Urna Samuelito en acero inoxidable de 2cm','Urna Samuelito en acero inoxidable de 2cm',
3,200000,490000,'Disponible',0.60,0.00);		 	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UAUTO','Urna auto servicio de 1,20mx60x1.90','Urna auto servicio de 1,20mx60x1.90',
3,400000,650000,'Disponible',0.34,0.00);				
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MCCP','Mueble caja curvo pequeño','Mueble caja curvo pequeño',
3,100000,190000,'Disponible',0.15,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MCCM','Mueble caja curvo mediano','Mueble de caja curvo mediano',
8,100000,290000,'Disponible',0.55,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MCCV','Mueble de caja curvo en vidrio curvo','Mueble de caja curvo en vidrio curvo',
8,300000,350000,'Disponible',0.10,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MCS','Mueble de caja samuelito','Mueble de caja samuelito',
8,200000,250000,'Disponible',0.10,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UCL','Urna curva en L','Urna curva en L',
8,1200000,1800000,'Disponible',0.26,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('USL','Urna Samuelito en L','Urna Samuelito en L',
8,1200000,1800000,'Disponible',0.26,0.00);			
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C1Q','Cocina de 1 quemador','Cocina de 1 quemador',
8,400000,80000,'Disponible',0.50,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C2Q','Cocina de 2 quemadores','Cocina de 2 quemadores',
4,80000,160000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C3Q','Cocina de 3 quemadores','Cocina de 3 quemadores',
4,100000,240000,'Disponible',0.61,0.00);		 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C4Q','Cocina de 4 quemadores','Cocina de 4 quemadores',
4,160000,320000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C5Q','Cocina de 5 quemadores','Cocina de 5 quemadores',
2,200000,400000,'Disponible',0.50,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C6Q','Cocina de 6 quemadores','Cocina de 6 quemadores',
2,200000,480000,'Disponible',0.58,0.00); 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('CMF','Cocina multifuncional en gas de 2 quemadores,plancha,horno, freidores'
,'Cocina multifuncional en gas de 2 quemadores,plancha,horno, freidores',2,400000,950000,'Disponible',0.64,0.00); 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('C2QP','Cocina de 2 quemadores y plancha industrial'
,'Cocina de 2 quemadores y plancha industrial',2,300000,360000,'Disponible',0.15,0.00); 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('P','Plancha industrial en gas'
,'Plancha industrial en gas',2,200000,250000,'Disponible',0.10,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('F1','Freidora sencilla de una canasta de 11 litros'
,'Freidora sencilla de una canasta de 11 litros',9,90000,180000,'Disponible',0.50,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('F2','Freidrora doble con tanque separado de 11 litros cada tanque'
,'Freidrora doble con tanque separado de 11 litros cada tanque',9,120000,360000,'Disponible',0.64,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UPC','Urna pollo curva pequeña con luz'
,'Urna pollo curva pequeña con luz',9,120000,260000,'Disponible',0.64,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UPS','Urna samuelito pequeña con luz'
,'Urna samuelito pequeña con luz',3,120000,190000,'Disponible',0.15,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UPCG','Urna curva para pollo con luces, resistencia con termosto'
,'Urna curva para pollo con luces, resistencia con termosto',3,120000,450000,'Disponible',0.70,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BM','Baño María con luces led 2 canastas grandes y 3 medios'
,'Baño María con luces led 2 canastas grandes y 3 medios',3,120000,450000,'Disponible',0.70,0.00);	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('ENFR','Ensaladera fria con luces led, urna abajo con vidrio'
,'Ensaladera fria con luces led, urna abajo con vidrio',5,420000,650000,'Disponible',0.27,0.00);	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FA45','Fermentador en acero inoxidable para 45 bandejas'
,'Fermentador en acero inoxidable para 45 bandejas',5,420000,450000,'Disponible',0.06,0.00);		 	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FG45','Fermentador en galvanizado inoxidable para 45 bandejas'
,'Fermentador en galvanizado inoxidable para 45 bandejas',7,420000,600000,'Disponible',0.18,0.00);
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FG15','Fermentador en galvanizado inoxidable para 15 bandejas'
,'Fermentador en galvanizado inoxidable para 15 bandejas',0,100000,274000,'Descontinuado',0.22,0.00);	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FA15','Fermentador en acero inoxidable para 15 bandejas'
,'Fermentador en acero inoxidable para 15 bandejas',0,100000,284000,'Descontinuado',0.58,0.00); 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FA454P','Fermentador en acero inoxidable para 45 bandejas 4 puertas'
,'Fermentador en acero inoxidable para 45 bandejas 4 puertas',0,100000,350000,'Descontinuado',0.78,0.00); 	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MT','Mesa de trabajo de 190x90x90 en acero inoxidable reforzada'
,'Mesa de trabajo de 190x90x90 en acero inoxidable reforzada',4,300000,650000,'Disponible',0.55,0.00);  
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('ME','Mesa de empaque de 190x90x90 en acero inoxidable reforazada'
,'Mesa de empaque de 190x90x90 en acero inoxidable reforazada',4,200000,254000,'Disponible',0.15,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MEP','Mesa de empaque pequeña 60x60x90 en acero inoxidable'
,'Mesa de empaque de 60x60x90 en acero inoxidable reforzada',1,200000,300000,'Disponible',0.25,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MEN','Mesa de empaque con niveles arriba de 190x90x90'
,'Mesa de empaque con niveles arriba de 190x90x90',5,200000,254000,'Disponible',0.08,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('MTP','Mesa de trabajo de 90x90x90 reforzada'
,'Mesa de trabajo de 90x90x90 reforzada',5,200000,500000,'Disponible',0.58,0.00);		 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('F1TP','Fregadero de 1 tanque pequeño de 1.0x90x90'
,'Fregadero de 1 tanque pequeño de 1.0x90x90',5,200000,290000,'Disponible',0.20,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('F2T','Fregadero de 2 tanques'
,'Fregadero de 2 tanques',6,200000,450000,'Disponible',0.59,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('F1TPN','Fregadero de 1 tanque pequeño con estantes aereos'
,'Fregadero de 1 tanque pequeño con estantes aereos',6,200000,390000,'Disponible',0.48,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('FGM','Fregadero grande con niveles puertas y estante para microondas'
,'Fregadero grande con niveles puertas y estante para microondas',6,500000,700000,'Disponible',0.21,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('UVFP','Urna vidrio fermentador para pan 15'
,'Urna vidrio fermentador para pan 15',9,150000,350000,'Disponible',0.61,0.00);		
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BLG','Bandeja lisa 45x65 aluminio #22'
,'Bandeja lisa 45x65 aluminio #22',9,2000,6500,'Disponible',0.70,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BLP','Bandeja lisa 30x70 aluminio #22'
,'Bandeja lisa 30x70 aluminio #22',9,2000,4500,'Disponible',0.57,0.00);	 	 
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BBG','Bandeja baguette 45x65 aluminio #22'
,'Bandeja baguette 45x65 aluminio #22',3,3000,8500,'Disponible',0.75,0.00);	 	 	
insert into products (codigo_producto,nombre_producto,descripcion,cantidad,precio_manufactura,precio_venta,estado_producto,
porcentaje_ganancia,porcentaje_descuento) values('BBP','Bandeja baguette 30x70 aluminio #22'
,'Bandeja baguette 30x70 aluminio #22',3,3000,6500,'Disponible',0.60,0.00);		

/*TBL USERS*/		
select * from users;
insert into users (cedula_user,primer_nombre_user,segundo_nombre_user,primer_apellido_user,segundo_apellido_user,
usuario,contrasena,tipo_user,estado_user) values('1-1747-0663','Lener','Steven','Herra','Ramírez','slherra','123456','Admin','Activo');
insert into users (cedula_user,primer_nombre_user,segundo_nombre_user,primer_apellido_user,segundo_apellido_user,
usuario,contrasena,tipo_user,estado_user) values('1-1234-5678','Flor','María','Navarro','Rojas','frojas','123456','Admin','Activo');

/*SALES & SALES_x_Products*/

INSERT INTO sales (clientID,userID,fecha_compra,monto_total,estado_factura) values(2,1,GETDATE(),1100000,'Completado');
INSERT INTO sales (clientID,userID,fecha_compra,monto_total,estado_factura) values(3,1,GETDATE(),1600000,'Completado');
INSERT INTO sales (clientID,userID,fecha_compra,monto_total,estado_factura) values(4,2,GETDATE(),1700000,'Procesando');

select * from sales;

INSERT INTO sales_x_products (compraID,productID,precio_factura_d) values (2,1,1100000);
INSERT INTO sales_x_products (compraID,productID,precio_factura_d) values (3,3,1600000);
INSERT INTO sales_x_products (compraID,productID,precio_factura_d) values (4,4,1700000);

select * from sales_x_products;
