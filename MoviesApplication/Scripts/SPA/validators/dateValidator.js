(function(app) {
    'use strict';
    app.directive("dateValidateCustom", dateValidateCustom);

    function dateValidateCustom() {

        function validate(scope, ele, attrs, ctrl) {
            ctrl.$validators.dateValidate = function (modelValue, viewValue) {

                var pattern = /\d{4}-\d{1,2}-\d{1,2}/g;

                if (ctrl.$isEmpty(viewValue))
                    return false;
                else if (viewValue.match(pattern) != null && viewValue.split('-').length == 3) {

                    var arrayDate = viewValue.split('-');
                       return Date.parse(arrayDate[0], arrayDate[1], arrayDate[2]) != NaN ? true : false;
                }
                return false;
            };
        };

        return {
            restrict: 'A',
            require : 'ngModel',
            link : validate
        };
    }

})(angular.module('homeCinema'));