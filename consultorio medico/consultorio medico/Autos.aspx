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

                              <!-- Sección de imágenes -->
                        <div class="row">
                            <div class="col-12">
                                <h4 class="mb-3">Imagenes del Producto</h4>
                                <div class="image-manager mb-3">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtNuevaImagen" runat="server"
                                            CssClass="form-control"
                                            placeholder="URL de la imagen" />
                                        <button type="button" class="btn btn-secondary" onclick="previewImage(); return false;">
                                            <i class="fas fa-eye"></i>Preview
               
                                        </button>
                                        <asp:Button ID="btnAgregarImagen" runat="server"
                                            Text="+"
                                            CssClass="btn btn-primary"
                                            OnClick="btnAgregarImagen_Click"
                                            CausesValidation="false" />
                                    </div>
                                    <!-- Preview de imagen -->
                                    <div id="imagePreview" class="mt-2 d-none">
                                        <img id="previewImg" src="" alt="Preview" class="img-fluid" style="max-height: 200px;" />
                                    </div>
                                </div>

                                <asp:Panel ID="pnlImagenes" runat="server" CssClass="image-list">
                                </asp:Panel>
                            </div>
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
      <style>
        .image-manager {
            background: #f8f9fa;
            padding: 1rem;
            border-radius: 8px;
        }

        .image-list {
            max-height: 300px;
            overflow-y: auto;
        }

        .image-item {
            display: flex;
            align-items: center;
            gap: 10px;
            margin-bottom: 10px;
            padding: 8px;
            background: #fff;
            border: 1px solid #dee2e6;
            border-radius: 4px;
        }

        .image-item .form-control {
            flex: 1;
        }

        .image-item .btn-remove {
            padding: 0.375rem 0.75rem;
        }
    </style>
    <script type="text/javascript">
        function previewImage() {
            var url = document.getElementById('<%= txtNuevaImagen.ClientID %>').value;
            var preview = document.getElementById('imagePreview');
            var img = document.getElementById('previewImg');

            if (url) {
                img.src = url;
                preview.classList.remove('d-none');

                img.onerror = function () {
                    preview.classList.add('d-none');
                    alert('No se pudo cargar la imagen. Verifique la URL.');
                };

                img.onload = function () {
                    preview.classList.remove('d-none');
                };
            } else {
                preview.classList.add('d-none');
            }
        }
    </script>
    </asp:Content>