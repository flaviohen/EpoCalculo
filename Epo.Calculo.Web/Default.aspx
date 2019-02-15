<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Epo.Calculo.Web._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div ng-controller="customersCtrl">
        <table>
            <tr>
                <th>
                    ID
                </th>
                <th>
                    Titulo
                </th>
                <th>
                    Ano
                </th>
                <th>
                    Nota
                </th>
            </tr>
            <tr ng-repeat="x in filmes">
                <td>
                    {{x.id}}
                </td>
                <td>
                    {{x.titulo}}
                </td>
                <td>
                    {{x.ano}}
                </td>
                <td>
                    {{x.nota}}
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
