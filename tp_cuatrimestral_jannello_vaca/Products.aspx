<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    <asp:UpdatePanel runat="server">
        <ContentTemplate>   <div style="height: 4em; left: 0; width: 100%; position:fixed; top: 6em; z-index:5; text-align:center; vertical-align:middle; padding-top:1em; color:white;
border-top:3px solid white; " 
     class="bg-blue">
        

    BUSCAR:&nbsp
    <asp:TextBox ID="products_buscar" runat="server" CssClass="drop" width="25%" AutoPostBack="false" OnTextChanged="products_buscar_TextChanged"></asp:TextBox>
    &nbsp&nbsp
    CATEGORIA:&nbsp
    <asp:DropDownList ID="products_categorias" runat="server" CssClass="drop" AutoPostBack="true" width="10%" OnSelectedIndexChanged="products_buscar_TextChanged"></asp:DropDownList>
    &nbsp&nbsp
    MARCA:&nbsp
    <asp:DropDownList ID="products_marca" runat="server" CssClass="drop" AutoPostBack="true" width="10%" OnSelectedIndexChanged="products_buscar_TextChanged"></asp:DropDownList>
    &nbsp&nbsp
    PRECIO: &nbsp
    <asp:TextBox ID="products_precioMinimo" placeholder="Mínimo" runat="server" CssClass="drop" AutoPostBack="false" width="5%" text-align="center" OnTextChanged="products_buscar_TextChanged"></asp:TextBox>
    &nbsp
    <asp:TextBox ID="products_precioMaximo" placeholder="Máximo" runat="server" CssClass="drop" AutoPostBack="false" width="5%" text-align="center" OnTextChanged="products_buscar_TextChanged"></asp:TextBox>

</div>
<div class="container">
  <div class="row">
    <% foreach (var producto in allProductos)
    {%>
        <div class="col-md-4">
            <div class="card h-100">
            <img src="<%= producto.URLimagen %>" class="card-img-top h-50" alt="Producto foto">
            <div class="card-body">
                <div>
                    <p class="h4 text-primary">$<%= producto.Precio.ToString("N2") %></p>
                </div>
                <p class="mb-0 text-secondary">
                <strong><%= producto.Nombre %></strong>
                </p>
                <p class="mb-1 text-secondary">
                <small>Detalle</small>
                </p>
                <div class="d-flex mb-3">
                <ul class="two-columns list-unstyled">
                    <li class="mb-0 small"><b>Código de producto: </b> <%= producto.CodigoArticulo %></li>
                    <li class="mb-0 small"><b>Marca: </b> <%= producto.Marca.Descripcion %></li>
                    <li class="mb-0 small"><b>Categoría: </b> <%= producto.Categoria.Descripcion %></li>
                </ul>
                </div>
                <div class="container-fluid">
                    <button class="btn btn-outline-primary btn-block" onclick="agregarProducto(<%= producto.Id %>)">
                        Agregar al carrito
                        <i class="fa fa-shopping-basket"></i>
                    </button>
                </div>
            </div>
            </div>
        </div>
    <% }%>
  </div>
</div>
<script>
    function agregarProducto(id) {
        Swal.fire({
            title: '¡Producto agregado!',
            text: 'Podrás verlo en tu carrito',
            icon:'success',
            timer: 1200,
            showConfirmButton: false
        })
        setTimeout(function () {
            var url = window.location.href
            if (url.indexOf('?') > -1) {
                url = url.substr(0, url.indexOf('?'))
                url += `?producto=${id}`
            } else {
                url += `?producto=${id}`
            }
            window.location.href = url
        }, 1500);
    }
</script>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
