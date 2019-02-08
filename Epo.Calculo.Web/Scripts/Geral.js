$(document).ready(function () {
});


function selecionarFilme(filmeSelecionado) {
    var array = [];

    $("input[type=checkbox]:checked").each(function (i) {
        array.push(i.value);
    });

    if (array.length > 8) {
        alert("Não é possivel selecionar mais que 8 filmes");
        filmeSelecionado.checked = false;
    }
    else {
        $("#QtdFilmesSelecionado").html(array.length + " - Filmes selecionados");
    }

    //alert(array.length);
}

