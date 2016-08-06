(function(app) {
    'use strict';

    app.directive('sideBar', sideBar);

    app.controller('sideBarController', sideBarController);

    sideBarController.$inject = ["$scope"];

    function sideBarController($scope) {

        $scope.status = {
            isopen: false
        };

        $scope.toggled = function (open) {
            $log.log('Dropdown is now: ', open);
        };

        $scope.toggleDropdown = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope.status.isopen = !$scope.status.isopen;
        };
    }

    function sideBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/spa/layout/sideBar.html',
            controller: sideBarController
    };
    };


})(angular.module('common.ui'));