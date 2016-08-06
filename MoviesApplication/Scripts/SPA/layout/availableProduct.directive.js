(function (app) {
    'use strict';

    app.directive('availableProduct', availableProduct);

    function availableProduct() {
        return {
            restrict: 'E',
            templateUrl: '/scripts/spa/layout/availableProduct.html',
            link : function($scope, $element, $attrs) {
                $scope.getAvailableClass = function () {
                    if ($attrs.isAvailable === 'true')
                        return 'label label-success';
                    else
                        return 'label label-danger';
                };
                $scope.getAvailability = function () {
                    if ($attrs.isAvailable === 'true')
                        return 'Available!'; ///language change
                    else
                        return 'Not Available'; ///language change
                };
            }
        };
    };
})(angular.module('common.ui'));