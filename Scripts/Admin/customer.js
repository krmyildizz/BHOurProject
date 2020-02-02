var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('CustomerController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings

    $scope.EnableEdit = false;
    $scope.selected = {};
    $("#addToTable").hide();
    $scope.getCustomerList = function () {
        //$http POST function
        $http({
            method: "post",
            url: "/Admin/Customer/GetCustomerList",
            data: JSON.stringify(),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCustomersList = response.data;
            $scope.EnableEdit = false;
            $scope.isAddCategory = false;
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    };

    $scope.cancelCustomer= function () {
        $scope.EnableEdit = false;
        $scope.isAddCategory = false;
        $("#addToTable").hide();
        location.reload();

    }
    $scope.editCustomer = function (item) {
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.openAddPage = function () {
        $("#addToTable").show();
        $scope.isAddCategory = true;
    }
    $scope.addCustomer = function () {
        $http({
            method: "post",
            url: "/Admin/Customer/SaveCustomer",
            data: JSON.stringify($scope.selectedValue),
            dataType: "json"
        }).then(function successCallback(response) {
            $("#addToTable").hide();
            $scope.getCustomerList();
        }, function errorCallback(response) {
            $scope.getCertificateList();
            console.log(response.errorCallback);
        });
    }
    $scope.deleteCustomer = function (id) {
        $http({
            method: "post",
            url: "/Admin/Customer/DeteteCustomer",
            data: JSON.stringify({ id: parseInt(id) }),
            dataType: "json"
        }).then(function successCallback(response) {

            $scope.getCustomerList();

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateCustomer = function () {

        $http({
            method: "post",
            url: "/Admin/Customer/UpdateCustomer",
            data: JSON.stringify($scope.selected),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.EnableEdit = false;
            $scope.getCustomerList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCustomerList();
    });




}]);