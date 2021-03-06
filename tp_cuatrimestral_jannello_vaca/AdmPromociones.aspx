<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmPromociones.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.AdmPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
<table class="table user-list" style="margin-bottom:0">
					<thead>
						<tr>
							<th><span>Nombre de promoción</span></th>
							<th><span>% Descuento</span></th>
							<th ><span>Activo</span></th>
						</tr>
					</thead>
					<tbody>

                        

						<tr class="bg-blue">
							<td style="width:39.7%">
								<asp:TextBox ID="DescuentoNombreNew" runat="server" TextMode="SingleLine"></asp:TextBox>
							</td>
							<td style="width:19.8%">
								<asp:TextBox ID="DescuentoPorcentajeNew" runat="server" MaxLength="5" AutoPostBack="false"></asp:TextBox>
							</td>
							<td style="width:20%; color:white">
                                <asp:CheckBox ID="DescuentoActivoNew" Text="Activo" runat="server" />
							</td>
							<td class="text-right" style="width:20.5%">
                                <asp:Button  ID="ButtonAdd" runat="server" Text="AGREGAR" class="btn btn-outline-light" Width="62%" OnClick="AgregarDescuento"/>
							</td>
						</tr>
                        </tbody>

</table>


                        <div style="height: 480px; overflow: scroll;" class="bg-blue">
                        <table class="table user-list">
                        
                        <asp:Repeater runat="server" ID="DescuentoRepeater">
                            <ItemTemplate>
						<tr class="bg-white">
							<td style="width:40%">
								<asp:TextBox ID="DescuentoNombre" runat="server" TextMode="SingleLine" AutoPostBack="false" Enabled="false"></asp:TextBox>
							</td>
							<td style="width:20%">
								<asp:TextBox ID="DescuentoPorcentaje" runat="server" TextMode="SingleLine" Min="0" Max="100" AutoPostBack="false"></asp:TextBox>
							</td>
							<td style="width:20%">
                                <asp:CheckBox ID="DescuentoActivo" Text="Activo" runat="server" />
							</td>

							<td class="text-right" style="width:20%">
								<asp:Button  ID="ButtonA" runat="server" Text="MODIFICAR"	class="btn btn-outline-primary" OnClick="MofidicarDescuento" CommandArgument='<%#Eval("Codigo") %>' />
								<asp:Button  ID="ButtonD" runat="server" Text="ELIMINAR"	class="btn btn-outline-danger"  OnClick="EliminarDescuento"  CommandArgument='<%#Eval("Codigo") %>'/>
							</td>
						</tr>
                        </ItemTemplate>
                        </asp:Repeater>

					</table>
                    </div>
			</ContentTemplate>
    </asp:UpdatePanel>

<script>
    function alertDatosVacios() {
        
        Swal.fire({
            title: '¡Datos vacíos!',
            text: 'Debes completar ambos campos antes de enviarlos',
            icon: 'error',
            timer: 1500,
            showConfirmButton: false
        })
	}
    function alertDescuentoRechazado() {
        Swal.fire({
            title: '¡Error!',
            text: 'Verifique los datos completados',
            icon: 'error',
            timer: 1500,
            showConfirmButton: false
        })
    }
    function alertDescuentoAgregado() {
        Swal.fire({
            title: '¡Descuento Agregado!',
            text: 'Haz agregado el descuento con éxito',
            icon: 'success',
            timer: 1500,
            showConfirmButton: false
        })
    }
    function alertDescuentoModificado() {
        Swal.fire({
            title: '¡Descuento Modificado!',
            text: 'Haz Modificado el descuento con éxito',
            icon: 'success',
            timer: 1500,
            showConfirmButton: false
        })
    }
    function alertDescuentoEliminado() {
        Swal.fire({
            title: '¡Descuento Eliminado!',
            text: 'Haz Eliminado el descuento con éxito',
            icon: 'success',
            timer: 1500,
            showConfirmButton: false
        })
    }
</script>

</asp:Content>
