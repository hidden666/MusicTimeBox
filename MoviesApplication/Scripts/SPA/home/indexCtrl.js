(function(app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['notificationService', 'apiService', '$scope'];

    function indexCtrl(notificationService, apiService, $scope) {
        $scope.pageClass = 'page-home';
        $scope.loadingMovies = true;
        $scope.loadingGenres = true;

        $scope.isReadOnly = true;

        $scope.latestMovies = [];
        $scope.loadData = loadData;

        function loadData() {
            apiService.get('/api/movies/latest', null, onMoviesLoadCompleted, onLoadFailed);
            apiService.get('/api/genres/latest', null, onGenresLoadCompleted, onLoadFailed);
        }

        function onGenresLoadCompleted(response) {
            var genres = response.data;
            Morris.Bar({
                element: "genres-bar",
                data: genres,
                xkey: "Name",
                ykeys: ["NumberOfMovies"],
                labels: ["Number Of Movies"],
                barRatio: 0.4,
                xLabelAngle: 55,
                hideHover: "auto",
                resize: 'true'
            });

            $scope.loadingGenres = false;
        }

        function onMoviesLoadCompleted(response) {
            $scope.latestMovies = response.data;
            $scope.loadingMovies = false;
        }

        function onLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        loadData();
    }

})(angular.module('homeCinema'));