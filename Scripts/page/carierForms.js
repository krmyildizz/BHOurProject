var myApp = angular.module('myApp', ['ngRoute', 'ngSanitize',]);
myApp.controller('CarrierController', ['$scope', '$http', function ($scope, $http) {

    $scope.selectedValue = {};
    //Create New User
    $scope.sendMailAndSaveCarrierForm = function () {
        $http({
            method: "post",
            url: "/Forms/SendMailAndSaveCarierForm",
            data: JSON.stringify($scope.selectedValue),
            dataType: "json"
        }).then(function successCallback(response) {
            alert("User has created Successfully")

        }, function errorCallback(response) {

            alert("Error. while created user Try Again!");

        });


    };
}]);