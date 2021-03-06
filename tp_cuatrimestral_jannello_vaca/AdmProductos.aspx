<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmProductos.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 class="ml-5 mb-5 col-5"> Administrar Productos </h2>
    <div class="d-flex align-items-center">
        <asp:Button ID="ButtonCrear" runat="server" Text="Crear nuevo" CssClass="btn btn-outline-info col-1 ml-5" OnClick="ButtonCrear_Click"/>
    </div>
    <div class="d-flex container-fluid justify-content-around mt-3">
        <div class="col-5" tabindex="Id">
        <asp:GridView 
            runat="server"
            ID="TablaProductos"
            AutoGenerateColumns="false"
            CssClass="table table-bordered"
        >
            <Columns>
                    <asp:BoundField DataField="CodigoArticulo"
                        HeaderText="Código" />
                    <asp:BoundField DataField="Nombre" 
                        HeaderText="Nombre" />
                    <asp:BoundField DataField="Marca" 
                        HeaderText="Marca" />
                    <asp:BoundField DataField="Categoria" 
                        HeaderText="Categoría" />
                    <asp:TemplateField>
                       <ItemTemplate>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="ButtonVerDetalle" CommandArgument='<% # Bind("Id") %>' runat="server" Text="Ver detalle" CssClass="btn btn-sm btn-info" onclick="ButtonVerDetalle_Click" />
                        <div>
                       </ItemTemplate>
                    </asp:TemplateField>

            </Columns>
        </asp:GridView>
        </div>
        <div class="col-7">
            <asp:Panel ID="PanelSelectedProducto" runat="server" Visible="false">
                <div class="d-flex">
                    <div class="form-group col-6">
                        <label>Nombre</label>
                        <asp:TextBox ID="TextBoxNombreProducto" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxNombreProducto_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El producto debe tener nombre" SetFocusOnError="true" ControlToValidate="TextBoxNombreProducto"></asp:RequiredFieldValidator>
                        <label>Descripción</label>
                        <asp:TextBox ID="TextBoxDescripcionProducto" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxDescripcionProducto_TextChanged"></asp:TextBox>
                        <label>Código de Producto</label>
                        <asp:TextBox ID="TextBoxCodigoProducto" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxCodigoProducto_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El producto debe tener un código" SetFocusOnError="true" ControlToValidate="TextBoxCodigoProducto"></asp:RequiredFieldValidator>
                        <label class="w-100">Marca</label>
                        <asp:DropDownList ID="DropDownListMarcas" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-1" OnSelectedIndexChanged="DropDownListMarcas_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label class="w-100">Categoría</label>
                        <asp:DropDownList ID="DropDownListCategorias" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-1" OnSelectedIndexChanged="DropDownListCategorias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label>Stock</label>
                        <asp:TextBox ID="TextBoxStock" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxStock_TextChanged"></asp:TextBox>
                        <asp:RangeValidator ErrorMessage="El stock tiene que ser mayor a cero y menor a 1000" MinimumValue="1" MaximumValue="999" runat="server" SetFocusOnError="true" ControlToValidate="TextBoxStock"></asp:RangeValidator>
                    </div>
                    <div class="form-group col-6">
                        <label>URL de la imagen</label>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TextBoxURLImagen" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxURLImagen_TextChanged"></asp:TextBox>
                                <asp:Image ID="ImageProducto" runat="server" CssClass="w-100" Height="300px"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <label>Precio</label>
                        <asp:TextBox ID="TextBoxPrecio" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxPrecio_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="ButtonGuardarCambios" runat="server" Text="Guardar cambios" CssClass="btn btn-outline-success ml-5" onclick="ButtonGuardarCambios_Click"/>
                <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar producto" CssClass="btn btn-outline-danger ml-5" onclick="ButtonEliminar_Click"/>
            </asp:Panel>
            <asp:Panel ID="PanelCreacionProducto" runat="server" Visible="false">
                <div class="d-flex">
                    <div class="form-group col-6">
                        <label>Nombre</label>
                        <asp:TextBox ID="TextBoxNombreCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxNombreCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El producto debe tener nombre" SetFocusOnError="true" ControlToValidate="TextBoxNombreProductoCreacion"></asp:RequiredFieldValidator>
                        <label>Descripción</label>
                        <asp:TextBox ID="TextBoxDescripcionCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxDescripcionCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <label>Código de Producto</label>
                        <asp:TextBox ID="TextBoxCodigoProductoCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxCodigoProductoCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El producto debe tener código" SetFocusOnError="true" ControlToValidate="TextBoxCodigoProductoCreacion"></asp:RequiredFieldValidator>
                        <label class="w-100">Marca</label>
                        <asp:DropDownList ID="DropDownListMarcasCreacion" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-1" OnSelectedIndexChanged="DropDownListMarcasCreacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label class="w-100">Categoría</label>
                        <asp:DropDownList ID="DropDownListCategoriasCreacion" DataTextField="Descripcion" DataValueField="Id" runat="server" CssClass="form-control mb-1" OnSelectedIndexChanged="DropDownListCategoriasCreacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label>Stock</label>
                        <asp:TextBox ID="TextBoxStockCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxStockCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RangeValidator ErrorMessage="El stock tiene que ser mayor a cero y menor a 1000" MinimumValue="1" MaximumValue="999" runat="server" SetFocusOnError="true" ControlToValidate="TextBoxStockCreacion"></asp:RangeValidator> 
                        </div>
                    <div class="form-group col-6">
                        <label>URL de la imagen</label>
                        <asp:UpdatePanel runat="server">
                           <ContentTemplate> 
                                <asp:TextBox ID="TextBoxURLImagenCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxURLImagenCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:Image ID="ImageCreacion" runat="server" CssClass="w-100" Height="300px"/>
                           </ContentTemplate> 
                        </asp:UpdatePanel>
                        <label>Precio</label>
                        <asp:TextBox ID="TextBoxPrecioCreacion" runat="server" CssClass="form-control font-weight-light mb-1" OnTextChanged="TextBoxPrecioCreacion_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="ButtonConfirmarCreacion" runat="server" Text="Crear producto" CssClass="btn btn-outline-success ml-5" onclick="ButtonConfirmarCreacion_Click"/>
                <asp:Button ID="ButtonCancelarCreacion" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger ml-5" OnClick="ButtonCancelarCreacion_Click" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
