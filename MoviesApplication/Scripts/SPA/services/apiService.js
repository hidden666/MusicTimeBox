(function(app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ["$http","$location", "notificationService", "$rootScope"];

    function apiService($http, $location, notifiationService, $rootScope)
    {
        function get(url, config, onSuccess, onError) {
            return $http.get(url, config).then(onSuccess, function onErrorInt(error) {
                if(error.status == '401') {
                    notifiationService.displayError('Authentication Required'); //// Language variable
                    $rootScope.previousState = $location.path();
                    $location.path('/login');
                }
                else if (error != null) {
                    onError(error);
                }
            });
        };
        
        function post(url, request, onSuccess, onError) {
            return $http.post(url, request).then(onSuccess, function onErrorInt(error) {
                if (error.status == '401') {
                    notifiationService.displayError('Authentication Required'); //// Language variable
                    $rootScope.previousState = $location.path();
                    $location.path('/login');
                }
                else if (error != null) {
                    onError(error);
                }
            });
        };

        return {
            get : get,
            post : post
        };
    };


})(angular.module('common.core'));