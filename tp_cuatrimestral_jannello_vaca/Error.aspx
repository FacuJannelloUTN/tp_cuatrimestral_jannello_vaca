<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <section class="d-flex justify-content-center flex-column align-items-center">  
    <h3>¡Ups! Algo malio sal...</h3>
    <div class="col-3"><img src="images/malirSal.jpg" alt="Malir sal" height="250"/></div>
    <h5>Je, es lo primero que sale mal</h5>
    <p><%= Session["error"] %></p>
    <div>
        <asp:Button ID="ButtonIrALogin" runat="server" Text="Ir a Login" CssClass="btn btn-outline-info" OnClick="ButtonIrALogin_Click"/>
        <asp:Button ID="ButtonIrAHome" runat="server" Text="Ir a Home" CssClass="btn btn-outline-info" OnClick="ButtonIrAHome_Click"/>
    </div>
  </section>
</asp:Content>
