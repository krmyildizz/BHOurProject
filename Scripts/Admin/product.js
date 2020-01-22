var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('ProductController', ['$scope', '$http', function ($scope, $http) {
    $scope.EnableEdit  = false;
    $scope.showAdd = function () {
        $scope.ShowReferance = true;
    }
    $scope.editProduct = function (item) {
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.showCancel = function () {
        $scope.EnableEdit  = false;
    }
    $scope.setFile = function (element) {
        $scope.currentFile = element.files[0];
        var reader = new FileReader();
        reader.onload = function (event) {
            $scope.ImageSourceIcon = event.target.result;
            $scope.$apply()
        }
        reader.readAsDataURL(element.files[0]);

    }
    $scope.getCustomerList = function () {
        $http({
            method: "post",
            url: "/Admin/Customer/GetCustomerList",
            data: JSON.stringify({}),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.customerList = response.data;

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });


    }

    $scope.getProductList = function () {
        $http({
            method: "post",
            url: "/Admin/Product/GetProductList",
            data: JSON.stringify({}),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.productList = response.data;
            
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.saveReferance = function () {
        $http({
            method: "post",
            url: "/Admin/Product/SaveProduct",
            data: JSON.stringify({ image: $scope.ImageSourceIcon, check: $scope.check, checkBanner: $scope.checkBanner, customerName: $scope.customerName }),
            dataType: "json"
        }).then(function successCallback(response) {
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateProduct= function (selected) {

        $http({
            method: "post",
            url: "/Admin/Product/UpdateCategory",
            data: JSON.stringify(selected),
            dataType: "json"
        }).then(function successCallback(response) {
            
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.deleteProduct = function (id) {
        $http({
            method: "post",
            url: "/Admin/Product/DeleteProduct",
            data: JSON.stringify({ id: parseInt(id) }),
            dataType: "json"
        }).then(function successCallback(response) {

            alert(response.data.message);

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getProductList();
        //$scope.getCustomerList();
    });
}]);
