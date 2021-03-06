﻿var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('ProductController', ['$scope', '$http', function ($scope, $http) {
    $scope.EnableEdit = false;
    $scope.showAddProduct = false;
    $scope.showAdd = function () {
        $scope.ShowReferance = true;
    }
    
    $scope.editProduct = function (item) {
        $scope.options = {
            "value":""+ item.Description2+""
        }
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
      

    }
  
    
    $scope.showCancel = function () {
        $scope.EnableEdit = false;
        $scope.showAddProduct = false;
        location.reload();
    }
    $scope.showAddProducts = function () {
        $scope.showAddProduct = true;
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
    $scope.setFilePdf = function (element) {
        $scope.currentFile = element.files[0];
        var reader = new FileReader();
        reader.onload = function (event) {
            $scope.Pdf = event.target.result;
            $scope.$apply()
        }
        reader.readAsDataURL(element.files[0]);

    }
   
   

    $scope.getProductList = function () {
        $http({
            method: "post",
            url: "/Admin/Product/GetProductList",
            data: JSON.stringify({}),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.productList = response.data;
            $scope.EnableEdit = false;
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.saveProduct = function () {
        $scope.selected.IsActive = $("#isActiveAdd").is(":checked");
        $http({
            method: "post",
            url: "/Admin/Product/SaveProduct",
            data: JSON.stringify({ product: $scope.selected, image: $scope.ImageSourceIcon, pdf: $scope.Pdf,subCategory: $scope.selected.subCategory }),
            dataType: "json"
        }).then(function successCallback(response) {
            $.confirm({
                title: 'Ekleme İşlemi',
                content: response.data.replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getProductList();
                    }
                }
            }

            );
            $scope.getProductList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateProduct= function () {
        $scope.selected.IsActive = $("#isActiveEdit").is(":checked");
        $http({
            method: "post",
            url: "/Admin/Product/UpdateCategory",
            data: JSON.stringify({ product: $scope.selected, subCategory: $scope.selected.CategoryId, image: $scope.ImageSourceIcon, pdf: $scope.Pdf}),
            dataType: "json"
        }).then(function successCallback(response) {
            $.confirm({
                title: 'Güncelleme İşlemi',
                content: response.data.replace('"',''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {
                    
                    Mesaj: function () {
                        $scope.getProductList();
                    }
                }
            }
                
            );
            $scope.getProductList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.getSubCategory = function () {
        $http({
            method: "post",
            url: "/Admin/Category/GetSubCategory",
            data: JSON.stringify({}),
            dataType: "json"
        }).then(function successCallback(response) {

            $scope.subCategory = response.data;

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
            $.confirm({
                title: 'Silme İşlemi',
                content: response.data.replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getProductList();
                    }
                }
            }

            );
            $scope.getProductList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getProductList();
        $scope.getSubCategory();

        //$scope.getCustomerList();
    });
}]);
