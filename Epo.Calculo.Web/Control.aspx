<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="Epo.Calculo.Web.Control" %>
<%@ Register Src="~/Teste.ascx" TagName="tgTeste"
    TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox3"
        runat="server"></asp:TextBox>
    <uc1:tgTeste ID="txtTeste" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>
