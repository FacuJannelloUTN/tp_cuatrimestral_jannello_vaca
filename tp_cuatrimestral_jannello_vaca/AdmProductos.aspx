<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmProductos.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center">
        <h2 class="mb-5 ml-5 col-4"> Administrar Productos </h2>
        <div class="col-2 mr-4">
          <asp:Button ID="ButtonCrear" runat="server" Text="Crear nuevo" CssClass="btn btn-outline-info" OnClick="ButtonCrear_Click"/>
          <div>
           <label>Ver detalle de producto</label>
            <asp:DropDownList ID="DDSelectionProduct"
                    runat="server"
                    CssClass="form-control mb-3"
                    AutoPostBack="true" DataTextField="Nombre" DataValueField="Id"
                    OnSelectedIndexChanged="DDSelectionProduct_SelectedIndexChanged"
                    ></asp:DropDownList>
         </div>
       </div>
    </div>
    <div class="d-flex container-fluid justify-content-around mt-3">
        <div class="col-7">
        <asp:GridView 
            runat="server"
            ID="TablaProductos"
            AutoGenerateColumns="false"
            CssClass="table table-bordered"
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
            <asp:Panel ID="PanelSelectedProducto" runat="server" Visible="false">
                <div class="d-flex">
                    <div class="form-group col-6">
                        <label>Nombre</label>
                        <asp:TextBox ID="TextBoxNombreProducto" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxNombreProducto_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Descripción</label>
                        <asp:TextBox ID="TextBoxDescripcionProducto" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxDescripcionProducto_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Código de Producto</label>
                        <asp:TextBox ID="TextBoxCodigoProducto" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxCodigoProducto_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label class="w-100">Marca</label>
                        <asp:DropDownList ID="DropDownListMarcas" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-3" OnSelectedIndexChanged="DropDownListMarcas_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label class="w-100">Categoría</label>
                        <asp:DropDownList ID="DropDownListCategorias" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListCategorias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label>Stock</label>
                        <asp:TextBox ID="TextBoxStock" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxStock_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-6">
                        <asp:Image ID="ImageProducto" runat="server" CssClass="w-100" Height="300px"/>
                        <label>URL</label>
                        <asp:TextBox ID="TextBoxURLImagen" runat="server" CssClass="form-control font-weight-light mb-5" OnTextChanged="TextBoxURLImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Precio</label>
                        <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxPrecio_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar producto" CssClass="btn btn-outline-danger ml-5" onclick="ButtonEliminar_Click"/>
            </asp:Panel>
            <asp:Panel ID="PanelCreacionProducto" runat="server" Visible="false">
                <div class="d-flex">
                    <div class="form-group col-6">
                        <label>Nombre</label>
                        <asp:TextBox ID="TextBoxNombreCreacion" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxNombreCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Descripción</label>
                        <asp:TextBox ID="TextBoxDescripcionCreacion" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxDescripcionCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Código de Producto</label>
                        <asp:TextBox ID="TextBoxCodigoProductoCreacion" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxCodigoProductoCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label class="w-100">Marca</label>
                        <asp:DropDownList ID="DropDownListMarcasCreacion" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-3" OnSelectedIndexChanged="DropDownListMarcasCreacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label class="w-100">Categoría</label>
                        <asp:DropDownList ID="DropDownListCategoriasCreacion" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListCategoriasCreacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label>Stock</label>
                        <asp:TextBox ID="TextBoxStockCreacion" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxStockCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="form-group col-6">
                        <asp:Image ID="ImageCreacion" runat="server" CssClass="w-100" Height="300px"/>
                        <label>URL</label>
                        <asp:TextBox ID="TextBoxURLImagenCreacion" runat="server" CssClass="form-control font-weight-light mb-5" OnTextChanged="TextBoxURLImagenCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Precio</label>
                        <asp:TextBox ID="TextBoxPrecioCreacion" runat="server" CssClass="form-control font-weight-light mb-3" OnTextChanged="TextBoxPrecioCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="ButtonConfirmarCreacion" runat="server" Text="Crear producto" CssClass="btn btn-outline-success ml-5" onclick="ButtonConfirmarCreacion_Click"/>
                <asp:Button ID="ButtonCancelarCreacion" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger ml-5" OnClick="ButtonCancelarCreacion_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
