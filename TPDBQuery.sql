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
  URLimagen varchar(50) null,
  idCategoria bigint not null foreign key references CategoriaProducto(id),
  idMarca bigint not null foreign key references MarcaProducto(id),
  idStock bigint not null foreign key references StockProducto(id),
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