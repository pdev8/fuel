(function () {
    angular.module(AppName).controller("userProfileController", UserProfileController);
    UserProfileController.$inject = ["$scope", "userProfileService"];

    function UserProfileController($scope, userProfileService) {

        var vm = this;

        vm.getAllUserProfiles = _getAllUserProfiles;
        vm.getUserProfile = _getUserProfile;
        vm.postUserProfile = _postUserProfile;
        vm.updateUserProfile = _updateUserProfile;
        vm.deleteUserProfile = _deleteUserProfile;
        
        vm.model = {};

        vm.$onInit = _init;

        function _init() {
            console.log("User profile controller loading");
        }

        function _getAllUserProfiles() {
            userProfileService.GetAllUserProfiles()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _getUserProfile() {
            userProfileService.GetUserProfileById()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postUserProfile() {
            userProfileService.CreateUserProfile()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _updateUserProfile() {
            userProfileService.EditUserProfile()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _deleteUserProfile() {
            userProfileService.DeleteUserProfile()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

    }

})();