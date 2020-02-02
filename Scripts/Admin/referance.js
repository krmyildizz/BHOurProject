var myAppAdmin = angular.module('myAppAdmin', ['ngRoute']);
myAppAdmin.controller('ReferanceController', ['$scope', '$http', function ($scope, $http) {
    $scope.ShowReferance = false;
    $scope.showAdd = function () {
        $scope.ShowReferance = true;
    }
    $scope.showCancel = function () {
        $scope.ShowReferance = false;
        $scope.EditReferance = false;
        location.reload();
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
    $scope.selectedId = function (item) {
        $scope.selected = angular.copy(item);
        
    }
    $scope.editReferance = function () {
        $scope.selectedValue = angular.copy($scope.selected);
        $scope.EditReferance = true;
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
    $scope.deleteReferance = function () {
        $http({
            method: "post",
            url: "/Admin/Slider/DeleteReference",
            data: JSON.stringify({ id: $scope.selected.Id }),
            dataType: "json"
        }).then(function successCallback(response) {
            $scope.getProductList();
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
            $.confirm({
                title: 'Prompt!',
                content: '' +
                    '<form action="" class="formName">' +
                    '<div class="form-group">' +
                    '<label>Enter something here</label>' +
                    '<input type="text" placeholder="Your name" class="name form-control" required />' +
                    '</div>' +
                    '</form>',
                buttons: {
                    formSubmit: {
                        text: 'Submit',
                        btnClass: 'btn-blue',
                        action: function () {
                            var name = this.$content.find('.name').val();
                            if (!name) {
                                $.alert('provide a valid name');
                                return false;
                            }
                            $.alert('Your name is ' + name);
                        }
                    },
                    cancel: function () {
                        //close
                    },
                },
                onContentReady: function () {
                    // bind to events
                    var jc = this;
                    this.$content.find('form').on('submit', function (e) {
                        // if the user submits the form by pressing enter in the field.
                        e.preventDefault();
                        jc.$$formSubmit.trigger('click'); // reference the button and click it
                    });
                }
            });
            }, function errorCallback(response) {
               

            console.log(response.errorCallback);
        });
    }
    $scope.updateReferance = function () {
        $http({
            method: "post",
            url: "/Admin/Slider/UpdateReferance",
            data: JSON.stringify({ image: $scope.ImageSourceIcon, check: $scope.selected.IsActive, checkBanner: $scope.selected.IsBanner, customerName: $scope.selected.CustomerName, id: $scope.selectedValue.Id}),
            dataType: "json"
        }).then(function successCallback(response) {
        }, function errorCallback(response) {

            console.log(response.errorCallback);
        });
    }
    $(document).ready(function () {
        $scope.getReferance();
        $scope.getCustomerList();
        $scope.EditReferance = false;
    });
}]);
