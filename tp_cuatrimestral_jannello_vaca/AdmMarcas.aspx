<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmMarcas.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-5"> Administrar Marcas </h2>
    <div class="d-flex justify-content-around mt-3">
        <asp:Table
            ID="TablaMarcas"
            runat="server"
            CssClass="col-4 table table-bordered"
        >
        </asp:Table>
        <div class="col-6">
            <div>
                <label>Crear nueva Marca</label>
                <asp:TextBox ID="TextBoxMarcaNueva" runat="server" CssClass="form-control font-weight-light col-10" Text="" placeholder="Ingrese un nombre"></asp:TextBox>
                <asp:Button ID="ButtonSubmitMarca" runat="server" Text="Crear" CssClass="btn btn-outline-primary" OnClick="ButtonSubmitMarca_Click"/>
            </div>
            <div class="mt-3">
                <label>Buscar por nombre</label>
                <asp:TextBox ID="TextBoxBuscarMarca" runat="server" CssClass="form-control font-weight-light col-10" Text="" placeholder="Ingrese un nombre" OnTextChanged="TextBoxBuscarMarca_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:Button ID="ButtonBuscarMarca" runat="server" Text="Buscar" CssClass="btn btn-outline-secondary" OnClick="ButtonBuscarMarca_Click"/>                
            </div>
            <div class="mt-3">
                <label>Eliminar por ID de marca</label>
                <asp:TextBox ID="TextBoxEliminarMarca" runat="server" CssClass="form-control font-weight-light col-5" Text="" placeholder="Ingrese un ID de marca" OnTextChanged="TextBoxEliminarMarca_TextChanged" AutoPostBack="true"></asp:TextBox>
                <asp:Button ID="ButtonEliminarMarca" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="ButtonEliminarMarca_Click"/>
                <asp:Label ID="LabelErrorEliminarMarca" runat="server" Text="Error al eliminar marca (¡Hay productos con esa marca!)" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
     </div>
</asp:Content>
