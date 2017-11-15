(function () {
    angular.module(AppName).factory("webScraperService", WebScraperService);
    WebScraperService.$inject = ["$http", "$q"];

    function WebScraperService($http, $q) {
        var srv = {
            GetRating: _getRating
        };

        return srv;

        function _getRating(model) {
            var defer = $q.defer();

            $http.post("/api/Trainers/url", model, { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }
    }


})();