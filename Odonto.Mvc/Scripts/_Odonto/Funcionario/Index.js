function OnSubmitSuccess(data) {
    if (data.sucesso) {
        swal(
            'Fornecedor',
            data.mensagem,
            'success'
        )
    } else {
        swal(
            'Oops...',
            data.mensagem,
            'error'
        )
    }

}

function OnSubmitBegin() {
    swal.showLoading();
}


$("#btnSalvar").click(function () {
    $("#frmSalvar").trigger("submit");
});

