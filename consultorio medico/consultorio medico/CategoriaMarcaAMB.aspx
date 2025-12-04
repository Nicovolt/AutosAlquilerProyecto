<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CategoriaMarcaAMB.aspx.cs" Inherits="consultorio_medico.CategoriaMarcaAMB" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        
<section class="contenedor">
        <asp:UpdatePanel ID="UpdatePanelCategorias" runat="server">
            <ContentTemplate>

                <div class="card-custom">
                    <div class="card-header-custom">
                        <h4>Agregar un nuevo auto</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-contenedor">
                          
                            
                            <div class="mb-3">
                                <label for="formGroupExampleInput"  class="form-label">categoria nueva</label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="txtCategoria" placeholder="modelo" />
                            </div>


                             <div class="form-group mb-3">
                              <label for="ddlCategoria" class="form-label">Seleccione la categoria a modificar</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                                 <asp:ListItem Text="Seleccione una Categoria" Value="" />
                                </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="rfvMCategoria" runat="server"
                                ControlToValidate="ddlCategoria"
                                 ErrorMessage="Seleccione una marca"
                                CssClass="text-danger" />
                             </div>
                             
                            <div class="mb-3">
                              <label for="formGroupExampleInput"  class="form-label">nuevo nombre de categoria</label>
                              <asp:TextBox runat="server" type="text" class="form-control" id="txtCategoriaEditada" placeholder="modelo" />
                            </div>
                           
                            <asp:Button Text="Agregar" ID="btnAgregar" OnClick="Agregar" CssClass="btn-custom btn-success-custom" runat="server" />
                            <asp:Button Text="Editar" OnClick="Editar" CssClass="btn-custom btn-success-custom" runat="server" />

                            <asp:Label runat="server" ID="lblError" CssClass="label-error" />
                            <asp:Label ID="lblMensajeError" runat="server" CssClass="label-error" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>

               

            </ContentTemplate>
        </asp:UpdatePanel>

    </section>







</asp:Content>