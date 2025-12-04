<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="DetalleAuto.aspx.cs" Inherits="consultorio_medico.DetalleAuto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 <asp:UpdatePanel ID="upProductoDetalle" runat="server">
    <ContentTemplate>
        <asp:GridView runat="server" ID="dgvProductoDetalle"></asp:GridView>
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-6" style="display: flex; flex-direction: column; justify-content: space-around; color: #000000">
                    <h2 style="text-align: center;">Detalle de producto</h2>
                    <hr />
                    <div style="display: flex; flex-direction: column;">
                        <span class="texto-secundario">Modelo:</span>
                        <asp:Label ID="lblNombreAuto" runat="server" Text="" CssClass="font-weight-bold"></asp:Label><br />
                        <span class="texto-secundario">Marca:</span>
                        <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label><br />
                        <span class="texto-secundario">Categoria: </span>
                        <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label><br />
                        <span class="texto-secundario">Anio: </span>
                        <asp:Label ID="lblAnio" runat="server" Text=""></asp:Label><br />
                        <span class="texto-secundario">Precio: </span>
                        <asp:Label ID="lblPrecio" runat="server" Text="" CssClass="font-weight-bold"></asp:Label>
                        <hr />
                        <div>
                            <asp:HiddenField ID="hfProductoID" runat="server" />
                            <asp:Button ID="btnCarrito" runat="server" OnClick="btnCarrito_Click" Text="Agregar al carrito" CssClass="btn btn-success" />
                            <asp:Button ID="btnBorrar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="idBorrar" OnClick="btnBorrar_Click" OnClientClick="return confirmDelete();" />
                            <asp:Button Text="Modificar" ID="btnModificar" commandname="idModificar" OnClick="btnEditar_Click" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6" style="height: 60vh;">
                    <div id="carouselExample" class="carousel slide" style="height: 100%;" data-bs-ride="carousel">
                        <div class="carousel-inner" style="height: 100%;">
                            <asp:Repeater ID="repeaterImagenes" runat="server">
                                <ItemTemplate>
                                    <div class='carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>' style="height: 200px;">
                                        <div class="imagen-carrusel">
                                            <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("UrlImagen") %>' CssClass="d-block w-100 artImagen" alt="No se pudo cargar la imagen" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <a class="carousel-control-prev" style="background-color: #123261;" href="#carouselExample" role="button" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </a>
                        <a class="carousel-control-next" style="background-color: #123261;" href="#carouselExample" role="button" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<script type="text/javascript">
    function confirmDelete() {
        return confirm('¿Estás seguro de que quieres eliminar este producto?');
    }
</script>
</asp:Content>