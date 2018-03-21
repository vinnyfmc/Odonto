(function () {
    var app = angular.module('FuncionarioLista', ['ngRoute']);

    app.controller('FuncionarioAPIController', function ($http, $scope) {

        
        $http({
            url: "/api/FuncionarioAPI/GetAll",
            method: "GET"
        }).then(function successCallback(response) {

            $scope.funcionarioList = response.data;
            
            $('#tblFuncionarios').DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
                }
            });
          
            }, function errorCallback(response) {
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: 'Algo deu errado, desculpe =('
                })
        });
        
    });

    $.fn.DetalharFuncionario = function (obj) {
        var table = $('#tblFuncionarios').DataTable();
        var data = table.row($(obj).closest('tr')).data();
        alert(data.Id);
        if (data.Id != null) {
            $http({
                url: "/Funcionario/Details",
                params: { idFuncionario: data.Id },
                method: "GET"
            })
        }
        else {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Algo deu errado, desculpe =('
            })
        }
    }
    
})();