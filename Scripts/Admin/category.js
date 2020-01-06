var myAppAdmin = angular.module('myAppAdmin');
myAppAdmin.controller('CategoryController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings
    $scope.submit = true;
    $scope.update = false;
    $scope.cancel = false;
    $scope.userid = true;

    $scope.selectedValue = {};
    $scope.getCategoryList = function () {

        //$http POST function
        $http({
            method: "post",
            url: "/Admin/Category/GetCategoryList",
            data: JSON.stringify(),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCategoryList = response.data;
            

        }, function errorCallback(response) {

                console.log(response.errorCallback);

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