var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('CompanyController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings
    $scope.EnableEdit = false;
    $scope.selected = {};
    $("#addToTable").hide();
    $scope.getCompanyList = function () {
        //$http POST function
        $http({
            method: "post",
            url: "/Admin/Company/GetCompanyList",
            data: JSON.stringify(),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCompanyList = response.data;
            $scope.EnableEdit = false;
            $scope.isAddCompany = false;


        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    };

    $scope.cancelCategory = function () {
        $scope.EnableEdit = false;
        $scope.isAddCategory = false;

    }
    $scope.editCompany = function (item) {
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.openAddPage = function () {
        $("#addToTable").show();
        $scope.isAddCompany= true;
    }
    $scope.addCompany = function () {

        $http({
            method: "post",
            url: "/Admin/Company/SaveCompany",
            data: JSON.stringify($scope.selected),
            dataType: "json"
        }).then(function successCallback(response) {
            $("#addToTable").hide();
            $.confirm({
                title: 'Ekleme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCompanyList();
                    }
                }
            });
            $scope.getCompanyList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.deleteCompany = function (id) {

        $http({
            method: "post",
            url: "/Admin/Company/DeleteCompany",
            data: JSON.stringify({ id: parseInt(id) }),
            dataType: "json"
        }).then(function successCallback(response) {

            $.confirm({
                title: 'Silme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCompanyList();
                    }
                }
            });
            $scope.getCompanyList();

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateCompany = function (selected) {

        $http({
            method: "post",
            url: "/Admin/Company/UpdateCompany",
            data: JSON.stringify(selected),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCompany = response.data;
            $.confirm({
                title: 'Güncelleme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCompanyList();
                    }
                }
            });
            $scope.getCompanyList();

        }, function errorCallback(response) {
 
            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCompanyList();
    });
    //Set $scope on Edit button click
  



}]);