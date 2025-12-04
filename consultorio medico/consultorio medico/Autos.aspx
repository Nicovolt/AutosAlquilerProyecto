<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Autos.aspx.cs" Inherits="consultorio_medico.Autos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section class="contenedor">
        <asp:UpdatePanel ID="UpdatePanelCategorias" runat="server">
            <ContentTemplate>

                <div class="card-custom">
                   <h3 class="mb-0">
                   <asp:Literal ID="ltlTitulo" runat="server" />
                   </h3>
                    <div class="card-body">
                        <div class="form-contenedor">
                            <div class="mb-3">
                                <label for="formGroupExampleInput" class="form-label">Modelo del auto</label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="txtModelo" placeholder="modelo" />
                            </div>


                             <div class="form-group mb-3">
                                    <label for="ddlMarca" class="form-label">Marca</label>
                                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Seleccione una Marca" Value="" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
                                        ControlToValidate="ddlMarca"
                                        ErrorMessage="Seleccione una marca"
                                        CssClass="text-danger" />
                                </div>


                            <div class="form-group mb-3">
                                    <label for="ddlCategoria" class="form-label">Categoria</label>
                                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Seleccione una categoria" Value="" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCategoria" runat="server"
                                        ControlToValidate="ddlCategoria"
                                        ErrorMessage="Seleccione una categoria"
                                        CssClass="text-danger" />
                                </div>


                            <div class="mb-3">
                              <label for="formGroupExampleInput" class="form-label">Patente</label>
                               <asp:TextBox runat="server" type="text" class="form-control" id="txtPatente" placeholder="patente" />
                            </div>


                            <div class="mb-3">
                              <label for="formGroupExampleInput" class="form-label">Año</label>
                               <asp:TextBox runat="server" type="number" class="form-control" id="txtAño" placeholder="año" />
                            </div>

                            <div class="mb-3">
                              <label for="formGroupExampleInput" class="form-label">Color</label>
                              <asp:TextBox runat="server" type="text" class="form-control" id="txtColor" placeholder="color" />
                            </div>

                            <div class="mb-3">
                             <label for="formGroupExampleInput" class="form-label">Precio</label>
                             <asp:TextBox runat="server" type="text" class="form-control" id="txtPrecio" placeholder="precio" />
                            </div>


                           
                            <asp:Button ID="btnAgregar" onclick="btnAgregar_Click" Text="Agregar" runat="server" CssClass="btn-custom btn-success-custom" />

                            <asp:Label runat="server" ID="lblError" CssClass="label-error" />
                            <asp:Label ID="lblMensajeError" runat="server" CssClass="label-error" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>

               

            </ContentTemplate>
        </asp:UpdatePanel>

    </section>
    </asp:Content>