var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('ReferanceController', ['$scope', '$http', function ($scope, $http) {
    $scope.ShowReferance = false;
    $scope.showAdd = function () {
        $scope.ShowReferance = true;
    }
    $scope.showCancel = function () {
        $scope.ShowReferance = false;
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
    $scope.test = function (item) {
        $scope.selected = angular.copy(item);
        $scope.text = $scope.checkModel;
    }
    $('#file_12').on("change", function () {
        alert("booyah");
    });

    $('#file_1').click(function () {
        alert($scope.selected.Id);
        })
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

    $scope.getReferance = function () {
        $http({
            method: "post",
            url: "/Admin/Slider/GetReferance",
            data: JSON.stringify({ }),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.referanceList = response.data;
           


        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $scope.saveReferance = function () {
        $http({
            method: "post",
            url: "/Admin/Slider/Addreferance",
            data: JSON.stringify({ image: $scope.ImageSourceIcon, check: $scope.check, checkBanner: $scope.checkBanner, customerName: $scope.selected.customerName }),
            dataType: "json"
        }).then(function successCallback(response) {
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getReferance();
        $scope.getCustomerList();
    });
}]);
