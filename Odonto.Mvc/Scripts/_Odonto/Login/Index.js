//$("#btnLogar").on("click", function () {
//    alert("clicou");
//    $("#frmLogin").trigger("submit");
//});
$(document).ready(function () {
    if ($.cookie("remmemberme") != null) {
        $("#remmemberme").prop('checked', true);
        $("#txEmail").val($.cookie("remmemberme"));
        $("#txSenha").focus();
    }
    
});



function onBegin() {
    
    if ($("#remmemberme").prop('checked')) {
        $.cookie("remmemberme", $("#txEmail").val());
    } else {
        $.removeCookie("remmemberme");
    }

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
