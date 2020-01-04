var myApp = angular.module('myApp', ['ngRoute','ngSanitize',]);
myApp.controller('RequestController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings
    $scope.submit = true;
    $scope.update = false;
    $scope.cancel = false;
    $scope.userid = true;

    $scope.selectedValue = {};


    //Create New User
    $scope.createUser = function () {

        //$http POST function
        $http({

            method: "post",
            url: "/Forms/SendMailAndSaveRequestForm",
            data: JSON.stringify($scope.selectedValue),
            dataType: "json"
        }).then(function successCallback(response) {

            //$scope.users.push(response.data);
            alert("User has created Successfully")

        }, function errorCallback(response) {

            alert("Error. while created user Try Again!");

        });

    };


   

    //Set $scope on Edit button click
    $scope.editUser = function (user) {

        $scope.user = user;
        $scope.submit = false;
        $scope.update = true;
        $scope.cancel = true;
        $scope.userid = false;

    };


    //cancel Uodate
    $scope.cancelUpdate = function () {
        $scope.user = null;
        $scope.submit = true;
        $scope.update = false;
        $scope.cancel = false;
        $scope.userid = true;
    };

 


}]);