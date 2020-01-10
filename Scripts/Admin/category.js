var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('CategoryController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings
  
    $scope.EnableEdit = false;
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

    $scope.cancelCategory = function () {
        $scope.EnableEdit = false;
        $scope.isAddCategory = false;
        
    }
    $scope.editCategory = function (item) {
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.openAddPage=function(){
        $("#addToTable").show();
        $scope.isAddCategory = true; 
    }
    $scope.addCategory = function () {
       
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
    $scope.deleteCategory = function (id) {
        $http({
            method: "post",
            url: "/Admin/Category/DeteteCategory",
            data: JSON.stringify(id),
            dataType: "json"
        }).then(function successCallback(response) {
            
            alert(response.data.message);

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateCategory = function (selected) {
       
        $http({
            method: "post",
            url: "/Admin/Category/UpdateCategory",
            data: JSON.stringify(selected),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCategoryList = response.data;
            alert(response.data.message);

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCategoryList();
    });
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