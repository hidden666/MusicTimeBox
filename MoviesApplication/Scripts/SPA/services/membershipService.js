(function(app) {

    'use strict';

    app.factory('membershipService', membershipService);

    membershipService.$inject = ['apiService', 'notificationService', '$http', '$base64', '$cookieStore', '$rootScope'];

    function membershipService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {

        var service = {
            login: login,
            register: register,
            saveCredentials: saveCredentials,
            isUserLoggedIn: isUserLoggedIn,
            removeCredentials: removeCredentials,
            getUserName: getUserName
        };

        function login(user, completed) {
            apiService.post('/api/account/authenticate', user, completed, failed);
        };

        function register(user, completed) {
            apiService.post('/api/account/register', user, completed, failed);
        }

        function saveCredentials(user) {
            var membershipData = $base64.encode(user.username + ':' + user.password);

            $rootScope.repository = {
                loggedUser: {
                    username: user.username,
                    authdata: membershipData
               }
            };
            $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
            $cookieStore.put('repository', $rootScope.repository);
        };

        function removeCredentials() {
            $rootScope.repository = {};
            $cookieStore.remove('repository');
            $http.defaults.headers.common.Authorization = '';
            notificationService.displayInfo("Successfully logged out");
        };

        function failed(response) { notificationService.displayError(response.data); };

        function isUserLoggedIn() {
            return $rootScope.repository.loggedUser != null;
        }

        function getUserName() {
            return $rootScope.repository.loggedUser.username;
        }

        return service;
    }


})(angular.module('common.core'));