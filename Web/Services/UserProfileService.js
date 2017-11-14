(function () {
   "use strict";

    angular.module(AppName).factory("userProfileService", UserProfileService);
    UserProfileService.$inject = ["$http", "$q"];

    function UserProfileService($http, $q) {

        var srv = {
            CreateUserProfile: _createUserProfile,
            EditUserProfile: _editUserProfile,
            DeleteUserProfile: _deleteUserProfile,
            GetUserProfileById: _getUserProfileById,
            GetAllUserProfiles: _getAllUserProfiles
        };

        return srv;

        function _createUserProfile(userProfileModel) {
            return $http.post("/api/UserProfiles", userProfileModel, { withCredentials: true })
                .then(function(response) {
                    return response.data;
                }).catch(function(err) {
                    return $q.reject(err);
                });
        }

        function _editUserProfile(userProfileModel) {
            return $http.post("/api/UserProfiles", userProfileModel, { withCredentials: true })
                .then(function(response) {
                    return response.data;
                }).catch(function(err) {
                    return $q.reject(err);
                });
        }

        function _deleteUserProfile(id) {
            return $http.delete("/api/UserProfiles/" + id, { withCredentials: true })
                .then(function(response) {
                    return response.data;
                }).catch(function(err) {
                    return $q.reject(err);
                });
        }

        function _getUserProfileById(id) {
            return $http.get("/api/UserProfiles/" + id, { withCredentials: true })
                .then(function(response) {
                    return response.data;
                }).catch(function(err) {
                    return $q.reject(err);
                });
        }

        function _getAllUserProfiles() {
            return $http.get("/api/UserProfiles", { withCredentials: true })
                .then(function(response) {
                    return response.data;
                }).catch(function(err) {
                    return $q.reject(err);
                });
        }

    }


})();