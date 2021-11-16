<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmProductos.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-5 ml-5"> Administrar Productos </h2>
    <div class="d-flex container-fluid justify-content-around mt-3">
        <div class="col-7">
        <asp:GridView 
            runat="server"
            ID="TablaProductos"
            AutoGenerateColumns="false"
            CssClass="table table-dark table-hover cursor-pointer"
        >
            <Columns>
                    <asp:BoundField DataField="Id" 
                        HeaderText="Id" ReadOnly="True" />
                    <asp:BoundField DataField="CodigoArticulo"
                        HeaderText="Código" />
                    <asp:BoundField DataField="Nombre" 
                        HeaderText="Nombre" />
                    <asp:BoundField DataField="Marca" 
                        HeaderText="Marca" />
                    <asp:BoundField DataField="Categoria" 
                        HeaderText="Categoría" />
                    <asp:BoundField DataField="Descripcion" 
                        HeaderText="Descripción" />
            </Columns>
        </asp:GridView>
        </div>
        <div class="col-5">
            <asp:Panel ID="PanelSelectedProducto" runat="server">
                <div class="d-flex">
                    <div class="form-group col-6">
                        <label>Nombre</label>
                        <asp:TextBox ID="TextBoxNombreProducto" runat="server" CssClass="form-control font-weight-light mb-3"></asp:TextBox>
                        <label>Descripción</label>
                        <asp:TextBox ID="TextBoxDescripcionProducto" runat="server" CssClass="form-control font-weight-light mb-3"></asp:TextBox>
                        <label>Código de Producto</label>
                        <asp:TextBox ID="TextBoxCodigoProducto" runat="server" CssClass="form-control font-weight-light mb-3"></asp:TextBox>
                        <label class="w-100">Marca</label>
                        <asp:DropDownList ID="DropDownListMarcas" runat="server" CssClass="form-control mb-3"></asp:DropDownList>
                        <label class="w-100">Categoría</label>
                        <asp:DropDownList ID="DropDownListCategorias" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-6">
                        <asp:Image ID="ImageProducto" runat="server" CssClass="w-100"/>
                        <label>URL</label>
                        <asp:TextBox ID="TextBoxURLImagen" runat="server" CssClass="form-control font-weight-light mb-5"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="ButtonGuardarCambios" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-success ml-3" />
                <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar producto" CssClass="btn btn-outline-danger ml-3" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
