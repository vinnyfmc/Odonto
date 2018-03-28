$(document).ready(function () {

    var table = $('.dataTable').DataTable({
        "ajax": '/Paciente/GetAll',
        "order": [[1, "desc"]],
        "columnDefs": [{
            "targets": 0,
            "data": null,
            "orderable": false,
            "defaultContent": "<button class='btn btn-primary fa fa-search cadastro' type='submit' value=''></button>"
        }, {
            "targets": 1,
            "data": "Nome",
            "orderable": true
        }, {
            "targets": 2,
            "data": "CPF",
            "orderable": true
        }, {
            "targets": 3,
            "data": "Telefone",
            "orderable": true
        }, {
            "targets": 4,
            "data": "Celular",
            "orderable": true
        }, {
            "targets": 5,
            "data": "Email",
            "orderable": true
        }

        ]
    });

    $('.dataTable tbody').on('click', '.cadastro', function () {
        var data = table.row($(this).parents('tr')).data();
        cadastro(data.Id);
    });

    function cadastro(id) {
        $("#hdfId").val(id);
    }

});