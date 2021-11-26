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
								<asp:TextBox ID="DescuentoPorcentajeNew" runat="server" TextMode="Number" MaxLength="5" AutoPostBack="false"></asp:TextBox>
							</td>
							<td style="width:20%; color:white">
                                <asp:CheckBox ID="DescuentoActivoNew" TextMode="Number" Text="Activo" runat="server" />
							</td>
							<td class="text-right" style="width:20.5%">
                                <asp:Button  ID="ButtonAdd" runat="server" Text="AGREGAR" class="btn btn-outline-light" Width="62%"/>
							</td>
						</tr>
                        </tbody>

</table>


                        <div style="height: 280px; overflow: scroll;" class="bg-blue">
                        <table class="table user-list">
                        
                        <asp:Repeater runat="server" ID="DescuentoRepeater">
                            <ItemTemplate>
						<tr class="bg-white">
							<td style="width:40%">
								<asp:TextBox ID="DescuentoNombre" runat="server" TextMode="SingleLine" AutoPostBack="false"></asp:TextBox>
							</td>
							<td style="width:20%">
								<asp:TextBox ID="DescuentoPorcentaje" runat="server" TextMode="SingleLine" Min="0" Max="100" AutoPostBack="false"></asp:TextBox>
							</td>
							<td style="width:20%">
                                <asp:CheckBox ID="DescuentoActivo" Text="Activo" runat="server" />
							</td>

							<td class="text-right" style="width:20%">
								<asp:Button  ID="ButtonA" runat="server" Text="MODIFICAR"		class="btn btn-outline-primary"  />
								<asp:Button  ID="ButtonD" runat="server" Text="ELIMINAR"		class="btn btn-outline-danger"  />
							</td>
						</tr>
                        </ItemTemplate>
                        </asp:Repeater>

					</table>
                    </div>
			</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
