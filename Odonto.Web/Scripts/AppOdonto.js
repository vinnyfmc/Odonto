//define aplicação angular e o controller
var app = angular.module("OdontoApp", []);
//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("empresasCtrl", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/home/GetEmpresas/'
    }).then(function successCallback(response) {
        console.log(response.data);
        $scope.empresas = response.data;
        
        }, function errorCallback(response) {
        console.log(response);
    });
    
});