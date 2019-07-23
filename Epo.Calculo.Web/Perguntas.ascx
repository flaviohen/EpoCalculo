<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Perguntas.ascx.cs" Inherits="Epo.Calculo.Web.Perguntas" %>
<div class="row">
    <asp:Label ID="DescricaoPergunta" runat="server" Text=""></asp:Label>
    <asp:HiddenField ID="hdnIDPergunta" runat="server" />
</div>
<div class="row">
    <asp:DropDownList ID="ddlResposta" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlResposta_SelectedIndexChanged">
    </asp:DropDownList>
</div>

