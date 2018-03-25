(function () {
    var app = angular.module('FuncionarioDetalhe', []);

    app.controller('FuncionarioAPIController', function ($scope) {
        $scope.funcionario = {};
        $scope.submit = function () {
            alert(JSON.stringify($scope.funcionario));
        }
    })

})