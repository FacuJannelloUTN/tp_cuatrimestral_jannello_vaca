<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="container">
  <div class="row">
    <div class="col-md-4">
      <div class="card h-100">
        <img src="https://http2.mlstatic.com/D_NQ_NP_682817-MLA47690303593_092021-O.webp" class="card-img-top" alt="Product">
        <div class="card-body">
          <div>
              <p class="h4 text-primary">$50,000</p>
          </div>
          <p class="mb-0 text-secondary">
            <strong>Televisor</strong>
          </p>
          <p class="mb-1 text-secondary">
            <small>Detalle</small>
          </p>
          <div class="d-flex mb-3">
            <ul class="two-columns list-unstyled">
              <li class="mb-0 small"><b>Código de producto: </b> #TLV2341</li>
              <li class="mb-0 small"><b>Marca: </b> Sony</li>
              <li class="mb-0 small"><b>Categoría: </b> Televisores</li>
            </ul>
          </div>
          <div class="container-fluid">
              <button class="btn btn-outline-primary btn-block">
                Agregar al carrito 
                <i class="fa fa-shopping-basket" aria-hidden="true"></i>
              </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</asp:Content>
