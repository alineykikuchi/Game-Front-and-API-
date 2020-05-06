function carregarOption(idItem, value, texto) {
    let componente = '<option value=' + value + '>' + texto + '</option>';
    $(idItem).append(componente);
}

function carregarEstrategias() {
    $.ajax({
        url: baseUrl + "RockPaperScissors/ConsultaEstrategias"
        , data: {}
        , type: "POST"
        , dataType: "Json"
    }).done(function (data) {
        var dadosEstategia = JSON.parse(data)
        dadosEstategia.forEach(function (objeto) { carregarOption($("#idEstrategia"), objeto.Chave, objeto.Estrategia) });
        $("#idEstrategia").val("");

        dadosEstategia.forEach(function (objeto) { carregarOption($("#idEstrategia2"), objeto.Chave, objeto.Estrategia) });
        $("#idEstrategia2").val("");
    }).fail(function () {

    });
}

var cadastroPartida = {
    Ordem: "",
    NamePlayer1: "",
    Strategy1: "",
    NameStrategy1: "",
    NamePlayer2: "",
    Strategy2: "",
    NameStrategy2: ""
};

function verificaVencedor() {
    $.ajax({
        url: baseUrl + "RockPaperScissors/VerificaVencedor"
        , data: {  }
        , type: "POST"
        , dataType: "Json"
    }).done(function (data) {
        var mensagem = JSON.parse(data);
        
        $("#idMensagemVencedor").html(mensagem);

    }).fail(function (error) {
        alert(error.status + "<--and--> " + error.statusText);
    });
};
$("#idVerificaVencedor").click(function () {
    verificaVencedor();
});

$("#idLimpar").click(function () {
    limparCampos();
})


function inserirPartida() {
    $.ajax({
        url: baseUrl + "RockPaperScissors/InserirPartida"
        , data: { cadastroPartida: model.cadastroPartida }
        , type: "POST"
        , dataType: "Json"
    }).done(function (data) {
        var partidas = JSON.parse(data);
        
        model.listaPartidas([]);
        model.listaPartidas(partidas);

        limparCampos();

    }).fail(function (error) {
        alert(error.status + "<--and--> " + error.statusText);
    });
};

function limparCampos() {
    $("#idOrdem").val('');

    $("#NomeJogador1").val('');
    $("#idEstrategia").val('');

    $("#NomeJogador2").val('');
    $("#idEstrategia2").val('');
}

$(function () {
    $("#idFormPartida").submit(function () {

        model.cadastroPartida.NameStrategy1 = $("#idEstrategia option:selected").text();
        model.cadastroPartida.NameStrategy2 = $("#idEstrategia2 option:selected").text();

        inserirPartida();
        return false;
    });
});

function ViewModel() {
    var self = this;
    self.listaPartidas = ko.observableArray([]);
    self.partidaSelecionado = ko.observable();

    self.selectThing = function (item) {
        self.partidaSelecionado(item);
    };

    self.cadastroPartida = ko.mapping.fromJS(cadastroPartida);
    

}
var model;

$(document).ready(function () {
    model = new ViewModel();
    ko.applyBindings(model);
});

carregarEstrategias();



(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));


$("#idOrdem").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});