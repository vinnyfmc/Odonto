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

function OnSubmitSuccess_AlterarSenha(data) {
    swal.hideLoading();
    if (data.sucesso) {
       
        swal({
            title: 'Paciente',
            text: data.mensagem,
            type: 'success',
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'OK!'
        }).then((result) => {
            window.location.href = $("#urlRedirect").val();
        })
        
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

$(".btnSubmit").click(function () {
    $(".frmSalvar").trigger("submit");
});


