(function () {
    angular.module(AppName).factory("userRoleService", UserRoleService);
    UserRoleService.$inject = ["$http", "$q"];

    function UserRoleService($http, $q) {
        var srv = {
            GetAllUserRoles: _getAllUserRoles
        };

        return srv;

        function _getAllUserRoles() {
            var defer = $q.defer();

            $http.get("/api/UserRoles", { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                    //console.log(response);
                    //console.log(response.data);
                })
                .catch(function(err) {
                    defer.reject(err);
                });

            return defer.promise;
        }
    }

})();