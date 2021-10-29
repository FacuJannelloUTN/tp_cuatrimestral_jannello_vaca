<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h1 class="animated bounceInDown">¡Somos SuperTech!</h1>
   <h3 class="animated bounceInDown">La mejor tienda online de electrodomésticos de zona norte</h3>
   <div class="home-cards-list">
      <a class="col-sm-8 col-md-3 col-lg-4 col-xl-2 card p-0 animated fadeInLeft" runat="server" href="~/Products">
            <img class="card-img-top bg-info rounded w-100" src="images/catalogo.png" />
            <div class="text-dark text-center"><h5 class="text-decoration-none">Ir a Catálogo</h5></div>
      </a>
      <a class="col-sm-8 col-md-3 col-lg-4 col-xl-2 card p-0 animated fadeInLeft" runat="server" href="~/ShoppingCart">
            <img class="card-img-top bg-info rounded w-100" src="images/shopping-cart.png" />
            <div class="text-dark text-center"><h5 class="text-decoration-none">Ver carrito</h5></div>
      </a>
      <a class="col-sm-8 col-md-3 col-lg-4 col-xl-2 card p-0 animated fadeInLeft" runat="server" href="~/Login">
            <img class="card-img-top bg-info rounded w-100" src="images/team.png" />
            <div class="text-dark text-center"><h5 class="text-decoration-none">Portal de empleados</h5></div>
      </a>
  </div>
</asp:Content>
