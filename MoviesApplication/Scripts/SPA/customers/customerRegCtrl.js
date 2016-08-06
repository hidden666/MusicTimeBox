(function(app) {
    'use strict';

    app.controller('customersRegCtrl', customerRegCtrl);

    customerRegCtrl.$inject = ['$scope', '$location', '$rootScope', 'apiService', 'notificationService'];

    function customerRegCtrl($scope, $location, $rootScope, apiService, notificationService) {

        $scope.newCustomer = {};

        $scope.register = register;
        $scope.openDatePicker = openDatePicker;
        $scope.dateOptions = {
            formatYear: 'yyyy',
            startingDay: 1
        };
        $scope.datepicker = {};

        function register() {
            apiService.post('/api/customer/register', $scope.newCustomer,
                registerCustomerSucceded,
                registerCustomerFailed);
        }

        function registerCustomerSucceded(response) {
            var customerRegistered = response.data;
            notificationService.displaySuccess($scope.newCustomer.LastName + ' has been successfully registed');
            notificationService.displayInfo('Check ' + customerRegistered.UniqueKey + ' for reference number');

            $scope.newCustomer = {};
            $scope.addCustomerForm.reset();
        }

        function registerCustomerFailed(response) {
            console.log(response);
            if (response.status == '400')
                notificationService.displayError('Registration failed\t\n' + response.data);
            else
                notificationService.displayError('Registration failed\t\n' + response.statusText);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

    };

})(angular.module('homeCinema'));