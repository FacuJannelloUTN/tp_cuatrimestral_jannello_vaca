<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmPromociones.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-5 mb-5 col-5"> Administrar Promociones </h2>
    <div class="d-flex align-items-center">
        <asp:Button ID="ButtonCrear" runat="server" Text="Crear nuevo" CssClass="btn btn-outline-info col-1 ml-5" />
    </div>
    <div class="d-flex container-fluid justify-content-around mt-3">
        <div class="card" style="width: 18rem;">
          <ul class="list-group list-group-flush">
            <% foreach (var descuento in allDescuentos)
                {%>
            <li class="list-group-item">
                <h3> <%= descuento.Codigo %></h3>
                <h5> <%= descuento.Porcentaje %></h5>
            </li>
            
            <% } %>
          </ul>
        </div>
    </div>
</asp:Content>
