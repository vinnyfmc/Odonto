(function () {
    //Cria um Module 
    // será usado ['ng-Route'] quando implementarmos o roteamento
    var app = angular.module('FuncionarioLista', ['ngRoute']);
    //Cria um Controller
    // aqui $scope é usado para compartilhar dados entre a view e o controller
    app.controller('FuncionarioController', function ($http, $scope) {
       
        $http({
            url: "/Funcionario/GetAll",
            method: "GET",
            params: { number: 4, name: "angular" }
        }).then(function successCallback(response) {
            var dados = response.data;
            if (dados.sucesso) {
                $scope.funcionarios = dados.retorno;
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