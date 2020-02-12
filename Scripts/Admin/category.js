﻿var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('CategoryController', ['$scope', '$http', function ($scope, $http) {

    $scope.EnableEdit = false;
    $scope.EnableAddSubCategory = false;
    $scope.selected = {};
    $("#addToTable").hide();
    $scope.getCategoryList = function () {
        //$http POST function
        $http({
            method: "post",
            url: "/Admin/Category/GetCategoryList",
            data: JSON.stringify(),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCategoryList = response.data;
            $scope.EnableEdit = false;
            $scope.isAddCategory = false;
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    };
    $scope.setFile = function (element) {
        $scope.currentFile = element.files[0];
        var reader = new FileReader();
        reader.onload = function (event) {
            $scope.ImageSourceIcon = event.target.result;
            $scope.$apply()
        }
        reader.readAsDataURL(element.files[0]);

    }
    $scope.cancelCategory = function () {
        $scope.EnableEdit = false;
        $scope.isAddCategory = false;
        $("#addToTable").hide();
        location.reload();

    }
    $scope.editCategory = function (item) {
        $("#isActiveEdit").prop('checked', item.IsActive);
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.openAddPage = function () {
        $("#addToTable").show();
        $scope.isAddCategory = true;
    }
    $scope.addCategory = function () {
        $scope.selected.IsActive = $("#isActiveAdd").is(":checked");
        $http({
            method: "post",
            url: "/Admin/Category/SaveCategory",
            data: JSON.stringify($scope.selectedValue),
            dataType: "json"
        }).then(function successCallback(response) {
            $("#addToTable").hide();
            alert(response.data.message);
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.EnableAddSubCategorys = function (item) {
        $scope.EnableAddSubCategory = true;
        $scope.selectedValue = angular.copy(item);

    }
    //$("#isActive").change(function () {
    //    if ($(this).is(":checked")) {
    //        $scope.selected.IsActive = true
    //    }


    //})
    $scope.addSubCategory = function () {
        $scope.selected.IsActive = $("#isActive").is(":checked");
        $http({
            method: "post",
            url: "/Admin/Category/SaveSubCategory",
            data: JSON.stringify({ sub: $scope.selected, categoryId: $scope.selectedValue.Id, image: $scope.ImageSourceIcon }),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.EnableAddSubCategory = false;
            $.toast({
                title: 'Notice!',
                subtitle: '11 mins ago',
                content: 'This is a toast message.',
                type: 'info',
                delay: 3000,
                //img: {
                //    src: 'image.png',
                //    class: 'rounded',
                //    title: '<a href="https://www.jqueryscript.net/tags.php?/Thumbnail/">Thumbnail</a> Title',
                //    alt: 'Alternative'
                //},
                pause_on_hover: false
            });

            $scope.getCategoryList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.deleteCategory = function (id) {
        $http({
            method: "POST",
            url: "/Admin/Category/DeleteCategory",
            data: JSON.stringify({ id: id }),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCategoryList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateCategory = function (selected) {
        selected.IsActive = $("#isActiveEdit").is(":checked");
        $http({
            method: "POST",
            url: "/Admin/Category/UpdateCategory",
            data: JSON.stringify(selected),
            dataType: "json"
        }).then(function successCallback(response) {

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCategoryList();
        $scope.EnableAddSubCategory = false;
    });
}]);