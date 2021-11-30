use master
go
Drop database TPFinalPrograIII

create database TPFinalPrograIII 
go
use TPFinalPrograIII
go
create table CategoriasProductos (
  id bigint not null primary key identity(1,1),
  nombre varchar(200) not null unique 
)
go
create table MarcasProductos (
  id bigint not null primary key identity(1,1),
  nombre varchar(200) not null unique 
)
go
create table Productos (
  id bigint not null primary key identity(10,10),
  precio money not null,
  codArticulo varchar(50) not null unique,
  nombre varchar(200) not null,
  descripcion varchar(300) not null,
  URLimagen varchar(400) null,
  stock bigint null,
  idCategoria bigint not null foreign key references CategoriasProductos(id),
  idMarca bigint not null foreign key references MarcasProductos(id),
  estado bit not null,
)
go
create table TiposDeUsuarios(
   id bigint not null primary key identity(1,1),
   nombre varchar(200) not null
)
go
create Table Usuarios (
   id bigint not null primary key identity(1,1),
   nombre varchar(30) null unique,
   contrasenia varchar(30) null,
   mail varchar(60) not null unique,
   idTipoDeUsuario bigint not null foreign key references TiposDeUsuarios(id)
)
go
create Table Carritos (
  id bigint not null primary key identity(1,1),
  codCompra varchar(200) not null unique,
  codDescuento varchar(200) null,
  idComprador bigint not null foreign key references Usuarios(id),
  conEnvio bit not null,
  fechaRealizado date not null,
  fechaEntregado date null,
  finalizado bit not null,
  entregado bit not null,
  monto money not null, 
)
go
create Table Descuentos (
 codigo varchar(200) not null unique,
 porcentaje decimal not null,
 estado bit not null,
)
go
create Table ProductosEnCarritos(
 idCarrito bigint not null foreign key references Carritos(id),
 idProducto bigint not null foreign key references Productos(id)
)
insert into CategoriasProductos(nombre)
values ('Televisor'), ('Celular'), ('Computadora'), ('Tablet'), ('Consola de juegos')
go
insert into MarcasProductos(nombre)
values ('Samsung'), ('Xiaomi'), ('LG'), ('Motorola'), ('Sanyo'), ('DELL')
insert into TiposDeUsuarios(nombre)
values ('Admin'), ('Cliente')
insert into Productos(precio, nombre, descripcion, codArticulo, URLimagen, idCategoria, idMarca, stock, estado)
values 
(50000, 'Smart TV', 'Una tele para toda la familia', 'TVG20231', 'https://http2.mlstatic.com/D_NQ_NP_682817-MLA47690303593_092021-O.webp', 1, 5, 80, 1),
(22000, 'MotoG30', 'Un celular que te hará vibrar de la emoción', 'CD220815', 'https://www.naldo.com.ar/medias/405422.jpg-515Wx515H?context=bWFzdGVyfHJvb3R8MTYxMzN8aW1hZ2UvanBlZ3xoNzAvaGEzLzk1ODgwNzEwMzkwMDYuanBnfGM2NWYwMzRhMzI0NzU0NWEwYjEwNjhjNDEwM2FlMjFmNGEzOTkzNWVhNzc0NDZhNmI0ZDNkMmJhNjZiNGI4YTY', 2, 4, 50, 1)
insert into Descuentos(codigo, porcentaje, estado)
values
('SUPER50', 50, 1),
('OPEN25', 25, 1),
('DEBAJA', 75, 0)

insert into Usuarios values 
('alanVaca', '12345678', 'alan-gabriel@hotmail.com', 1),
('alanVacaCliente', '12345678', 'alanVacaCliente@hotmail.com', 2),
('facuJanello', '12345678', 'facundojannellobaldi@gmail.com', 1),
('facuJanelloCliente', '12345678', 'facuJanelloCliente@hotmail.com', 2)

use TPFinalPrograIII
go
select * from Carritos

Select C.id id, C.codCompra, C.codDescuento, C.idComprador, C.conEnvio, C.fechaRealizado, C.fechaEntregado, C.finalizado, C.entregado, C.monto,
D.estado 'estadoDescuento', D.porcentaje 'porcentajeDescuento', U.nombre 'nombreUsuario', U.contrasenia 'contraseniaUsuario', U.mail 'mailUsuario', U.idTipoDeUsuario 'tipoUsuario'
from Carritos C
inner join Descuentos D on D.codigo = C.codDescuento
inner join Usuarios U on U.id = C.idComprador

"Update Descuentos set porcentaje = 7500,estado = 1 where codigo = 'DEBAJA'"