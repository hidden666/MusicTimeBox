(function(app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', 'membershipService'];

    function rootCtrl($scope, membershipService) {

        $scope.userData = {};
        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.userData.isUserLoggedIn = isUserLoggedIn;
        $scope.userData.logout = logout;


        function displayUserInfo() {
            return membershipService.getUserName();
        };

        function isUserLoggedIn() {
            return membershipService.isUserLoggedIn();
        }

        function logout() {
            return membershipService.removeCredentials();
        };

    }


})(angular.module('homeCinema'));