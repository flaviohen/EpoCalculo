<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadExcel.aspx.cs" Inherits="Epo.Calculo.Web.UploadExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Excel</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImportar" runat="server" Text="Importar" OnClick="btnImportar_Click" />
        </div>
        <div style="clear: both; width: 1000px; overflow: auto; margin-top: 10px;">
            <asp:GridView ID="GridView1" runat="server" CssClass="table">
            </asp:GridView>
        </div>
        <div style="clear: both; width: 1000px; margin-top: 10px;" runat="server" id="MensagemErros"
            class="alert alert-danger">
        </div>
        <div style="clear: both; width: 1000px; margin-top: 10px;" runat="server" id="MensagemSucesso"
            class="alert alert-success">
            <strong>Os dados foram carregado com sucesso, e estão pronto para fazer a importação</strong>
        </div>
    </div>
    </form>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
