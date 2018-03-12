(function () {
    var app = angular.module('FuncionarioLista', ['ngRoute']);

    app.controller('FuncionarioController', function ($http, $scope) {
        
        $http({
            url: "/Funcionario/GetAll",
            method: "GET"
        }).then(function successCallback(response) {
            var dados = response.data;
            if (dados.sucesso) {
                $('#tblFuncionarios').DataTable({
                    data: dados.retorno,
                    columns: [{
                        title: 'ID',
                        data: 'Id'
                    }, {
                        title: 'Razão Social',
                        data: 'RazaoSocial'
                    }, {
                        title: 'CNPJ',
                        data: 'CNPJ'
                    }],
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
                    }
                    
                });
            } else {
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: dados.retorno
                })
            }
            }, function errorCallback(response) {
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: 'Algo deu errado, desculpe =('
                })
        });
        
    });




})();