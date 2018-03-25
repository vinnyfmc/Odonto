$(document).ready(function () {

    var table = $('#tblFuncionarios').DataTable({
        "ajax": '/Empresa/GetAll',
        "columnDefs": [{
            "targets": 0,
            "data": null,
            "orderable": false,
            "defaultContent": "<i class='btn btn-primary fa fa-search detalharFuncionario'></i>"
        }, {
            "targets": 1,
            "data": "RazaoSocial",
            "orderable": true
        }, {
            "targets": 2,
            "data": "CNPJ",
            "orderable": true
        }

        ]
    });

    $('#tblFuncionarios tbody').on('click', '.detalharFuncionario', function () {
        var data = table.row($(this).parents('tr')).data();
        detalharFuncionario(data.Id);
    });

    function detalharFuncionario(id) {
        $.post("/Funcionario/Detail", { id: id });
    }

});