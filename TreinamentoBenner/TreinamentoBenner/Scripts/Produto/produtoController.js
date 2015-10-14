(function() {
    "use strict";

    angular.module("app", ["ngRoute"]);

    angular.module("app").config(function($routeProvider) {
        $routeProvider.when("/list", {
            templateUrl: "/Produto/List",
            controller: "ListController"
        }).when("/create", {
            templateUrl: "/Produto/Edit",
            controller: "EditController"
        }).when("/edit/:id", {
            templateUrl: "/Produto/Edit",
            controller: "EditController"
        }).when("/delete/:id", {
            templateUrl: "/Produto/Delete",
            controller: "DeleteController"
        }).otherwise({
            redirectTo: "/list"
        });
    });

    angular.module("app").controller("ListController", function($scope, $http) {
        $http.get("/api/Produto").success(function(data) {
            $scope.Produtos = data;
        });
    });

    angular.module("app").controller("EditController", function ($scope, $http, $routeParams, $location) {
        var id = $routeParams.id;

        if (id > 0) {
            $scope.title = "Editando produto";

            $http.get("/api/Produto/" + id).success(function(data) {
                $scope.Produto = data;
            });
        } else {
            $scope.title = "Novo produto";
        }

        $scope.save = function() {
            if ($scope.Produto.Id === 0) {
                $scope.create();
            } else {
                $scope.update();
            }
        };

        $scope.create = function() {
            $http.put("/api/Produto", $scope.Produto).success(function() {
                $location.path("/list");
            }).error(function(data) {
                $scope.Error = data.ExceptionMessage;
            });
        };

        $scope.update = function() {
            $http.put("/api/Produto", $scope.Produto).success(function(data) {
                $location.path("/list");
            }).error(function(data) {
                $scope.Error = data.ExceptionMessage;
            });
        };
    });

    angular.module("app").controller("DeleteController", function ($scope, $http, $routeParams, $location) {
        var id = $routeParams.id;

        $http.get("/api/Produto/" + id).success(function(data) {
            $scope.Produto = data;
        });

        $scope.delete = function() {
            $http.delete("/api/Produto/" + id).success(function() {
                $location.path("/list");
            }).error(function(data) {
                $scope.Error = data.ExceptionMessage;
            });
        };
    });
})();