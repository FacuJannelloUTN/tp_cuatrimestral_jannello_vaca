<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmPedidos.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<article class="ml-5">
 <h2>Administración de pedidos</h2>
 <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
    <li class="nav-item">
        <a class="nav-link active" id="pill-pendientes" data-toggle="pill" href="#tab-entregados" role="tab" aria-controls="tab-pendientes" aria-selected="true">Pendientes</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" id="pill-entregados" data-toggle="pill" href="#tab-pendientes" role="tab" aria-controls="tab-entregados" aria-selected="false">Entregados</a>
    </li>
 </ul>
 <div class="tab-content" id="pills-tabContent">
    <div class="tab-pane fade show active" id="tab-entregados" role="tabpanel" aria-labelledby="pill-pendientes">
       <div class="d-flex container-fluid mt-3">
          <div class="col-5" tabindex="Id">
            <asp:GridView 
                runat="server"
                ID="TablaPedidosPendientes"
                AutoGenerateColumns="false"
                CssClass="table table-bordered"
            >
                <Columns>
                        <asp:BoundField DataField="CodCompra"
                            HeaderText="Código" />
                        <asp:BoundField DataField="Comprador.Nombre" 
                            HeaderText="Nombre del cliente" />
                        <asp:TemplateField HeaderText="Monto de la compra" >
                            <ItemTemplate>
                                $<%# Eval("MontoTotal") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                           <ItemTemplate>
                            <div class="d-flex flex-column justify-content-center">
                                <asp:Button ID="ButtonVerDetalle" CommandArgument='<% # Bind("Id") %>' runat="server" Text="Ver detalle" CssClass="btn btn-sm btn-outline-info" />
                                <asp:Button ID="ButtonConfirmarEntrega" CommandArgument='<% # Bind("Id") %>' runat="server" Text="Confirmar entrega" CssClass="btn btn-sm btn-outline-success" onclick="ButtonConfirmarEntrega_Click"/>                            
                            <div>
                           </ItemTemplate>
                        </asp:TemplateField>

                </Columns>
            </asp:GridView>
          </div>
       </div>
    </div>
    <div class="tab-pane fade" id="tab-pendientes" role="tabpanel" aria-labelledby="pill-entregados">
       <div class="d-flex container-fluid mt-3">
          <div class="col-5" tabindex="Id">
            <asp:GridView 
                runat="server"
                ID="TablaPedidosEntregados"
                AutoGenerateColumns="false"
                CssClass="table table-bordered"
            >
                <Columns>
                        <asp:BoundField DataField="CodCompra"
                            HeaderText="Código" />
                        <asp:BoundField DataField="Comprador.Nombre" 
                            HeaderText="Nombre del cliente" />
                        <asp:TemplateField HeaderText="Monto de la compra" >
                            <ItemTemplate>
                                $<%# Eval("MontoTotal") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                           <ItemTemplate>
                            <div class="d-flex flex-column justify-content-center">
                                <asp:Button ID="ButtonVerDetalle" CommandArgument='<% # Bind("Id") %>' runat="server" Text="Ver detalle" CssClass="btn btn-sm btn-outline-info" />
                                <asp:Button ID="ButtonReabrirPedido" CommandArgument='<% # Bind("Id") %>' runat="server" Text="Reabrir pedido" CssClass="btn btn-sm btn-outline-danger" OnClick="ButtonReabrirPedido_Click" />                            
                            <div>
                           </ItemTemplate>
                        </asp:TemplateField>

                </Columns>
            </asp:GridView>
          </div>
       </div>
    </div>
 </div>
</article>
</asp:Content>
