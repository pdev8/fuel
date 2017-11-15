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

        vm.Submit = _submit;

        vm.arrayWeeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

        vm.model = {};

        vm.$onInit = _init;

        function _init() {
            console.log("User profile controller loading");
        }

        function _submit() {



            // clear form
            vm.model = {};
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
            userProfileService.GetUserProfileById(id)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postUserProfile() {
            userProfileService.CreateUserProfile(vm.model)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _updateUserProfile() {
            userProfileService.EditUserProfile(vm.model)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _deleteUserProfile() {
            userProfileService.DeleteUserProfile(id)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

    }

})();