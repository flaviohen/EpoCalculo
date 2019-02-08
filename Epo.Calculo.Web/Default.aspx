<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Epo.Calculo.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
      <h2 id="QtdFilmesSelecionado">0 Filmes Selecionado</h2>
    </div>
    <div class="row" id="Filmes">
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="1" class="form-control" value="1" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="2" class="form-control" value="2" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="3" class="form-control" value="3" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="4" class="form-control" value="4" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="5" class="form-control" value="5" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="6" class="form-control" value="6" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="7" class="form-control" value="7" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="8" class="form-control" value="8" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="9" class="form-control" value="9" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="10" class="form-control" value="10" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="11" class="form-control" value="11" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="12" class="form-control" value="12" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="13" class="form-control" value="13" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="14" class="form-control" value="14" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="15" class="form-control" value="15" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
        <div class="col-md-3" style="background-color:Black; color:White; border:1px solid white;">
            <div style="float: left; width: 20px;">
                <input type="checkbox" id="16" class="form-control" value="16" onchange="selecionarFilme(this)" />
            </div>
            <div style="float: left; width: 150px;">
                <label>
                    Titulo do Filme</label>
                <label>
                    Ano</label>
            </div>
        </div>
    </div>
</asp:Content>
