create database TPFinalPrograIII 
go
use TPFinalPrograIII
go
create table CategoriaProducto (
  id bigint not null primary key identity(1,1),
  nombre varchar(200) not null unique 
)
go
create table MarcaProducto (
  id bigint not null primary key identity(1,1),
  nombre varchar(200) not null unique 
)
go
create table StockProducto (
  id bigint not null primary key identity(1,1),
  cantidad bigint not null 
)
go 
create table Productos (
  id bigint not null primary key identity(10,10),
  precio money not null,
  descripcion varchar(300) not null,
  URLimagen varchar(400) null,
  idCategoria bigint not null foreign key references CategoriaProducto(id),
  idMarca bigint not null foreign key references MarcaProducto(id),
  idStock bigint not null foreign key references StockProducto(id) unique,
)
go
create table TipoDeUsuario(
   id bigint not null primary key identity(1,1),
   nombre varchar(200) not null
)
go
create Table Usuarios (
   id bigint not null primary key identity(100,1),
   nombre varchar(30) not null,
   contrasenia varchar(30) not null,
   mail varchar(60) not null,
   idTipoDeUsuario bigint not null foreign key references TipoDeUsuario(id)
)
go
create Table Carritos (
  id bigint not null primary key identity(1,1),
  codDescuento varchar(200) null,
  idComprador bigint not null foreign key references Usuarios(id),
  finalizado bit not null,
)
go
create Table ProductoEnCarrito (
 idCarrito bigint not null foreign key references Carritos(id),
 idProducto bigint not null foreign key references Productos(id),
 conEnvio bit not null,
 precioDeVenta money not null
)
go
create Table Pedido (
 idCarrito bigint not null foreign key references Carritos(id),
 entregado bit not null
)
go
insert into CategoriaProducto(nombre)
values ('Televisor'), ('Celular'), ('Computadora'), ('Tablet'), ('Consola de juegos')
go
insert into MarcaProducto(nombre)
values ('Samsung'), ('Xiaomi'), ('LG'), ('Motorola'), ('Sanyo'), ('DELL')
insert into TipoDeUsuario(nombre)
values ('Admin'), ('Cliente')
insert into StockProducto(cantidad)
values (100),(80), (29), (42), (44)
insert into Productos(precio, descripcion, URLimagen, idCategoria, idMarca, idStock)
values 
(50000, 'Smart TV', 'https://http2.mlstatic.com/D_NQ_NP_682817-MLA47690303593_092021-O.webp', 1, 5, 1),
(22000, 'MotoG30', 'https://www.naldo.com.ar/medias/405422.jpg-515Wx515H?context=bWFzdGVyfHJvb3R8MTYxMzN8aW1hZ2UvanBlZ3xoNzAvaGEzLzk1ODgwNzEwMzkwMDYuanBnfGM2NWYwMzRhMzI0NzU0NWEwYjEwNjhjNDEwM2FlMjFmNGEzOTkzNWVhNzc0NDZhNmI0ZDNkMmJhNjZiNGI4YTY', 2, 4, 2)
