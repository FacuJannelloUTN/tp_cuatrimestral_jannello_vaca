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
  finalizado bit not null,
  entregado bit not null,
  monto money not null, 
)
go
create Table Descuentos (
 codigo varchar(200) not null unique,
 porcentaje decimal not null
)
go
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
insert into Descuentos(codigo, porcentaje)
values
('SUPER50', 50),
('OPEN25', 25)

insert into Usuarios values 
('alanVaca', '12345678', 'alan-gabriel@hotmail.com', 1),
('alanVacaCliente', '12345678', 'alanVacaCliente@hotmail.com', 2),
('facuJanello', '12345678', 'facundojannellobaldi@gmail.com@hotmail.com', 1),
('facuJanelloCliente', '12345678', 'facuJanelloCliente@hotmail.com', 2)

Select  P.id id,P.codArticulo,P.nombre,P.descripcion,M.nombre 'marca',C.nombre 'categoria',
		P.URLimagen,P.precio, P.idMarca IdMarca, P.idCategoria IdCategoria, P.stock from Productos P 
		inner join MarcasProductos M on M.id=P.idMarca
		inner join CategoriasProductos C on C.id=P.idCategoria where P.estado = 1
		and P.nombre like '%tv%'

		Select  P.id id,P.codArticulo,P.nombre,P.descripcion,M.nombre 'marca',C.nombre 'categoria',
		P.URLimagen,P.precio, P.idMarca IdMarca, P.idCategoria IdCategoria, P.stock from Productos P 
		inner join MarcasProductos M on M.id=P.idMarca 
		inner join CategoriasProductos C on C.id=P.idCategoria where P.estado = 1
		and P.Precio >= 23000
		
