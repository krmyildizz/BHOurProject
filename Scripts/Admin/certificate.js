var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('CertificateController', ['$scope', '$http', function ($scope, $http) {

    //Buttons Settings

    $scope.EnableEdit = false;
    $scope.selected = {};
    $("#addToTable").hide();
    $scope.getCertificateList = function () {
        //$http POST function
        $http({
            method: "post",
            url: "/Admin/Certificate/GetCertificateList",
            data: JSON.stringify(),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getCertificateList = response.data;
            $scope.EnableEdit = false;
            $scope.isAddCategory = false;
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    };

    $scope.cancelCertificate = function () {
        $scope.EnableEdit = false;
        $scope.isAddCategory = false;
        $("#addToTable").hide();

    }
    $scope.editCertificate = function (item) {
        $scope.EnableEdit = true;
        $scope.selected = angular.copy(item);
    }
    $scope.openAddPage = function () {
        $("#addToTable").show();
        $scope.isAddCategory = true;
    }
    $scope.addCertificate = function () {
        $http({
            method: "post",
            url: "/Admin/Certificate/SaveCertificate",
            data: JSON.stringify($scope.selectedValue),
            dataType: "json"
        }).then(function successCallback(response) {
            $("#addToTable").hide();
            $scope.getCertificateList();
        }, function errorCallback(response) {
                $scope.getCertificateList();
            console.log(response.errorCallback);
        });
    }
    $scope.deleteCertificate = function (id) {
        $http({
            method: "post",
            url: "/Admin/Certificate/DeteteCertificate",
            data: JSON.stringify({ id: parseInt(id) }),
            dataType: "json"
        }).then(function successCallback(response) {

            $scope.getCertificateList();

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.updateCertificate = function () {

        $http({
            method: "post",
            url: "/Admin/Certificate/UpdateCertificate",
            data: JSON.stringify($scope.selected),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.EnableEdit = false;

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCertificateList();
    });
   



}]);