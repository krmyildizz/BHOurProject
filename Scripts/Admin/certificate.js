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
            $scope.getCertificate = response.data;
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
        location.reload();

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
            $.confirm({
                title: 'Ekleme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCertificateList();
                    }
                }
            }); $scope.getCertificateList();

        }, function errorCallback(response) {
                $scope.getCertificateList();
            console.log(response.errorCallback);
        });
    }
    $scope.deleteCertificate = function (id) {
        $http({
            method: "post",
            url: "/Admin/Certificate/DeleteCertificate",
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
                        $scope.getCertificateList();
                    }
                }
                });
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
            $.confirm({
                title: 'Güncelleme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCertificateList();
                    }
                }
            }); $scope.getCertificateList();

        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCertificateList();
    });
   



}]);