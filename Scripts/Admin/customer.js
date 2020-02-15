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
            $scope.getCustomers = response.data;
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
            $.confirm({
                title: 'Ekleme İşlemi',
                content: response.data.replace('"', '').replace('"',''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCustomerList();
                    }
                }
            }

            );
            $scope.getCustomerList();
           
        }, function errorCallback(response) {
            $scope.getCertificateList();
            console.log(response.errorCallback);
        });
    }
    $scope.deleteCustomer = function (id) {
        $http({
            method: "post",
            url: "/Admin/Customer/DeleteCustomer",
            data: JSON.stringify({ id: parseInt(id) }),
            dataType: "json"
        }).then(function successCallback(response) {
            $.confirm({
                title: 'Güncelleme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCustomerList();
                    }
                }
            }

            );
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
            $.confirm({
                title: 'Silme İşlemi',
                content: response.data.replace('"', '').replace('"', ''),
                type: 'green',
                backgroundDismiss: true,
                typeAnimated: true,
                autoClose: 'Mesaj|1000',
                buttons: {

                    Mesaj: function () {
                        $scope.getCustomerList();
                    }
                }
            }

            );
            $scope.getCustomerList();
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getCustomerList();
    });




}]);