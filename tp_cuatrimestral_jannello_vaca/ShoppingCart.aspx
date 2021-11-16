<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="container">
  <div class="row">
    <div class="col-lg-8">
        <div>
          <h5 class="mb-4">Productos en Carrito (<span>2</span> productos)</h5>
          <div class="row mb-4">
            <div class="col-md-5 col-lg-3 col-xl-3">
              <div class="rounded mb-3 mb-md-0">
                <img class="img-fluid w-100"
                  src="https://http2.mlstatic.com/D_NQ_NP_682817-MLA47690303593_092021-O.webp" alt="Producto en carrito">
              </div>
            </div>
            <div class="col-md-7 col-lg-9 col-xl-9">
                    <div>
                        <div class="d-flex justify-content-between">
                            <div>
                                <h5>Televisor Smart TV</h5>
                                <p class="mb-2 text-muted text-uppercase small">Marca: <asp:Label Text="LG" runat="server" /></p>
                                <p class="mb-3 text-muted text-uppercase small">Categoría: <asp:Label Text="Televisores" runat="server" /></p>
                            </div>
                            <div>
                                <div>
                                    <span class="col-4">Cantidad: </span>
                                    <asp:TextBox runat="server" CssClass="col-4" min="0" ID="quantity" Text="1"  
                                     TextMode="Number" onkeypress="javascript:return ValidarNumerosEnteros(event)" AutoPostBack="true" ></asp:TextBox>
                                
                                <script>
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
                                </script>
                                </div>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <a href="#!" type="button" class="small text-uppercase mr-3">Eliminar item </a>
                            </div>
                            <p class="mb-0">Precio por unidad: <span><strong>$50.000</strong></span></p>
                        </div>
                    </div>
                </div>
            </div>
         </div>
   </div>
   <div class="col-lg-4">

      <div class="mb-3">
          <div class="pt-4">
              <h5 class="mb-3"><i class="fa fa-shopping-cart"></i> Mi carrito</h5>
              <ul class="list-group list-group-flush">
                  <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0">Productos
                    <span>$150.000</span>
                  </li>
                  <li class="list-group-item d-flex justify-content-between align-items-center px-0">Descuento
                    <asp:Label ID="LabelDescuento" runat="server" Text="0%"></asp:Label>
                  </li>
                  <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                      <div>
                          <strong>Total de compra</strong>
                      </div>
                      <span><strong>$150.000</strong></span>
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

 </div>
</section>
</asp:Content>
