<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="container">
  <div class="row">
    <div class="col-lg-8">
        <div>
          <h5 class="mb-4">Productos en Carrito (<span><%= Carrito.Productos.Count.ToString() %></span> productos)</h5>
          <% 
              List<long> productosMostrados = new List<long>();
              foreach (var producto in Carrito.Productos)

              {
                  if (!productosMostrados.Contains(producto.Id))
                  {
                      productosMostrados.Add(producto.Id);
             %>
            <div class="row mb-4">
            <div class="col-md-5 col-lg-3 col-xl-3">
              <div class="rounded mb-3 mb-md-0">
                <img class="img-fluid w-100"
                  src="<%= producto.URLimagen %>" alt="<%= producto.Nombre %>">
              </div>
            </div>
            <div class="col-md-7 col-lg-9 col-xl-9">
                    <div>
                        <div class="d-flex justify-content-between">
                            <div class="col-6">
                                <h5><%= producto.Nombre %></h5>
                                <p class="mb-2 text-muted text-uppercase small">Marca: <%= producto.Marca %></p>
                                <p class="mb-3 text-muted text-uppercase small">Categoría: <%= producto.Categoria %> </p>
                            </div>
                            <div class="col-6 d-flex">
                                <div class="col-12">
                                    <span>Cantidad: </span>
                                    <span class="col-2"><%= Carrito.Productos.Where(p => p.Id == producto.Id).Count() %></span>
                                    <button class="col-2 btn btn-sm btn-danger rounded-circle" onclick="variarCantidad(-1,<%= producto.Id %>)">-</button>
                                    <button class="col-2 btn btn-sm btn-success rounded-circle" onclick="variarCantidad(1, <%= producto.Id %>)">+</button>
                                <!-- <script>
                                    function ValidarNumerosEnteros(e) {
                                        var key;
                                        if (window.event) {
                                            key = e.keycode;
                                        }
                                        else if(e.which) {
                                            key = e.which;
                                        }
                                        if (key < 48 || key > 57) { return false; } return true;
                                    }
                                </script> -->
                                </div>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <a href="#" type="button" class="small text-uppercase mr-3" onclick="variarCantidad(0, <%= producto.Id %>)">Eliminar item </a>
                            </div>
                            <p class="mb-0">Precio por unidad: <span><strong><%= producto.Precio.ToString("N2") %></strong></span></p>
                        </div>
                    </div>
                </div>
            </div>
            <% }
            } %>
         </div>
   </div>
   <div class="col-lg-4">

      <div class="mb-3">
          <div class="pt-4">
              <h5 class="mb-3"><i class="fa fa-shopping-cart"></i> Mi carrito</h5>
              <ul class="list-group list-group-flush">
                  <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0">Productos
                    <span>$<%= Carrito.Productos.Aggregate(decimal.Parse("0"),(a,b) => a += b.Precio).ToString("N2") %></span>
                  </li>
                  <li class="list-group-item d-flex justify-content-between align-items-center px-0">Descuento
                    <label><%= Carrito.Descuento.Porcentaje %> %</label>
                  </li>
                  <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                      <div>
                          <strong>Total de compra</strong>
                      </div>
                      <span>$
                          <strong><% if (Descuento == 0){ %>
                                  <%= Carrito.Productos.Aggregate(decimal.Parse("0"),(a,b) => a += b.Precio).ToString("N2") %>   
                                  <% } else { %>
                                  <%= (Carrito.Productos.Aggregate(decimal.Parse("0"),(a,b) => a += b.Precio)*Descuento/100).ToString("N2") %>
                                  <% } %>
                          </strong>
                      </span>
                  </li>
              </ul>
              <button type="button" class="btn btn-primary btn-block">Realizar pedido</button>
          </div>
      </div>

      <div class="mb-3">
        <div class="pt-4">
            <a class="d-flex justify-content-between" data-toggle="collapse" href="#box-descuento"
                aria-expanded="false" aria-controls="box-descuento">
                    Agregar código de descuento (opcional)
            </a>
            <div class="collapse" id="box-descuento">
                <div class="mt-3">
                    <div class="md-form md-outline mb-0">
                        <asp:TextBox ID="TextBoxCodigoDescuento" runat="server" CssClass="form-control font-weight-light col-10" Text="" placeholder="Ingrese código de descuento"></asp:TextBox>
                        <div class="input-group-append">
                                <asp:Button ID="ButtonSubmitCodigo" runat="server" Text="Ingresar" CssClass="btn btn-outline-primary" OnClick="ButtonSubmitCodigo_Click"/>
                                <asp:Label ID="LabelMensajeRespuestaCodigo" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      </div>

   </div>
<script>
    function variarCantidad(cantidad, id) {
        var url = window.location.href
        if (url.indexOf('?') > -1) {
            url = url.substr(0, url.indexOf('?'))
            url += cantidad == 1
                ? `?aumentar=${id}`
                : cantidad == -1
                    ? `?reducir=${id}`
                    : `?reducirTodo=${id}`
        } else {
            url += cantidad == 1
                ? `?aumentar=${id}`
                : cantidad == -1
                    ? `?reducir=${id}`
                    : `?reducirTodo=${id}`
        }
        console.log(url)
        window.location.href = url
    }
</script>

 </div>
</section>
</asp:Content>
