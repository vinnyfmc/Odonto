(function () {
    //Cria um Module 
    // será usado ['ng-Route'] quando implementarmos o roteamento
    var app = angular.module('FuncionarioLista', ['ngRoute']);
    //Cria um Controller
    // aqui $scope é usado para compartilhar dados entre a view e o controller
    app.controller('FuncionarioController', function ($http, $scope) {
        $scope.Mensagem = "Olá.  Esse é nosso primeiro contato com o AgularJS no ASP .NEt MVC.";

        $http({
            url: "/Funcionario/GetAll",
            method: "GET",
            params: { number: 4, name: "angular" }
        }).then(function successCallback(response) {
            var dados = response.data;
            if (dados.sucesso) {
                $scope.funcionarios = dados.retorno;
            } else {
                alert(dados.retorno);
            }
            }, function errorCallback(response) {
                console.log(response.data);
        });
        
    });




})();