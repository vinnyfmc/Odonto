//$("#btnLogar").on("click", function () {
//    alert("clicou");
//    $("#frmLogin").trigger("submit");
//});

function onBegin() {
    $("#txEmail").val("");
    $("#txSenha").val("");
    $('#btnLogar').attr('disabled');
    swal.showLoading();
}

function onSuccess(data) {
    if (data.Ok) {
        window.location.href = $(".data-url").attr("data-redirect");
    }
    else {
        swal(
            'Oops...',
            data.Mensagem,
            'error'
        )
        swal.hideLoading();
    }
}
