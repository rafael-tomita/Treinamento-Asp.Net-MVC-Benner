var app = angular.module("app", []);
app.controller("CidadeController", function($scope, $http, params) {
    function clear() {
        $scope.cidade = {};
        $scope.editing = false;
        $scope.cidadeEditing = null;
    }

    $http.get(params.urlList).success(function(data) {
        $scope.cidades = data;
    });

    $scope.add = function() {
        $http.post(params.urlAdd, $scope.cidade).success(function(data) {
            if (data.Status) {
                $scope.cidades.push(data.Model);
                clear();
            }
        });
    };

    $scope.edit = function(cidade) {
        $scope.cidade = cidade;
        $scope.cidades.splice($scope.cidades.indexOf(cidade), 1);
        $scope.editing = true;
        $scope.cidadeEditing = cidade;
    };

    $scope.cancel = function() {
        $scope.cidades.push($scope.cidadeEditing);
        clear();
    };

    $scope.remove = function(cidade) {
        $http.post(params.urlRemove, { Id: cidade.Id}).success(function(data) {
            if (data.Status) {
                $scope.cidades.splice($scope.cidades.indexOf(cidade), 1);
            }
        });
    };
});