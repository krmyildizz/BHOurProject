angular.module('myApp', []).
    controller("HelloController", function ($scope) {
        $scope.helloTo = {};
        $scope.helloTo.title = "AngularJS";
    });