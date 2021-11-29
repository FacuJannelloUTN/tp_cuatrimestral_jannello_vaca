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
    <div class="tab-pane fade show active" id="tab-entregados" role="tabpanel" aria-labelledby="pill-pendientes">Pedidos pendientes
        <%= Carritos.Count %>
        <% foreach (var c in Carritos)
            { %>
        <h5>Carrito con ID:  <%= c.Comprador.Nombre %></h5>
        <%} %>
    </div>
    <div class="tab-pane fade" id="tab-pendientes" role="tabpanel" aria-labelledby="pill-entregados">Pedidos entregados</div>
 </div>
</article>
</asp:Content>
