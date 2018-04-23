var app = angular.module('myModule', []);
app.service('ngservice', function ($http) {
    this.getOrders = function () {
        var res = $http.get("/api/ContatosAPI/");
        return res;
    };

});


app.controller('myController', function ($scope, ngservice) {
    //$scope.selecionar = ["Nome", "Email", "Usuario"];
    //$scope.criterio = ""; 
    //$scope.filtro = ""; 

    loadOrders();
    var expectFriendNames = function (expectedNames, key) {
        element.all(by.repeater(key + ' in Orders').column(key + '.Nome')).then(function (arr) {
            arr.forEach(function (wd, i) {
                expect(wd.getText()).toMatch(expectedNames[i]);
            });
        });
    };

    function loadOrders() {

        var promise = ngservice.getOrders();
        promise.then(function (resp) {
            $scope.Orders = resp.data;
            $scope.Message = "Dados Carregados";
        }, function (err) {
            $scope.Message = "Falha " + err.status;
        });
    };


});