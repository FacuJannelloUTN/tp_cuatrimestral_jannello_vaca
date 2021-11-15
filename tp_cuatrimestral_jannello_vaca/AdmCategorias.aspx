<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmCategorias.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2 class="mb-5"> Administrar Categorías </h2>
    <div class="d-flex justify-content-around mt-3">
        <asp:Table
            ID="TablaCategorias"
            runat="server"
            CssClass="col-4 table table-bordered"
        >
        </asp:Table>
        <div class="col-6">
            <div>
                <label>Crear nueva Categoria</label>
                <asp:TextBox ID="TextBoxCategoriaNueva" runat="server" CssClass="form-control font-weight-light col-10" Text="" placeholder="Ingrese un nombre"></asp:TextBox>
                <asp:Button ID="ButtonSubmitCategoria" runat="server" Text="Crear" CssClass="btn btn-outline-primary" OnClick="ButtonSubmitCategoria_Click"/>
            </div>
            <div class="mt-3">
                <label>Buscar por nombre</label>
                <asp:TextBox ID="TextBoxBuscarCategoria" runat="server" CssClass="form-control font-weight-light col-10" Text="" placeholder="Ingrese un nombre" OnTextChanged="TextBoxBuscarCategoria_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:Button ID="ButtonBuscarCategoria" runat="server" Text="Buscar" CssClass="btn btn-outline-secondary" OnClick="ButtonBuscarCategoria_Click"/>                
            </div>
            <div class="mt-3">
                <label>Eliminar por ID de categoría</label>
                <asp:TextBox ID="TextBoxEliminarCategoria" runat="server" CssClass="form-control font-weight-light col-5" Text="" placeholder="Ingrese un ID de categoría" OnTextChanged="TextBoxEliminarCategoria_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:Button ID="ButtonEliminarCategoria" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="ButtonEliminarCategoria_Click"/>
                <asp:Label ID="LabelErrorEliminarCategoria" runat="server" Text="Error al eliminar categoría (¡Hay productos de esa categoría!)" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
     </div>
</asp:Content>
