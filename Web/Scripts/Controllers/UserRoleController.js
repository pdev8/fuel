(function () {
    angular.module(AppName).controller("userRoleController", UserRoleController);
    UserRoleController.$inject = ["$scope", "userRoleService", "trainerService"];


    function UserRoleController($scope, userRoleService, trainerService) {
        var vm = this;

        vm.userProfileModel = {
            firstName: "",
            lastName: "",
            email: "",
            profileImageUrl: ""
        };

        vm.trainerModel = {
            bio: "",
            userProfileId: 0
        };

        vm.package = {
            firstName: vm.userProfileModel.firstName,
            lastName: vm.userProfileModel.lastName,
            email: vm.userProfileModel.email,
            profileImageUrl: vm.userProfileModel.profileImageUrl,
            bio: vm.trainerModel.bio,
            userProfileId: vm.trainerModel.userProfileId
        };

        vm.userRoles = [];
        vm.roleTypes = [];
        vm.getUserRoles = _getUserRoles;
        vm.getRoleTypes = _getRoleTypes;
        vm.postTrainer = _postTrainer;

        vm.$onInit = _init;

        function _init() {
            _getUserRoles();
        }

        function _getUserRoles() {
            userRoleService.GetAllUserRoles()
                .then(function (data) {
                    vm.userRoles = data.Items;
                    _getRoleTypes();

                    console.log(vm.userRoles);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _getRoleTypes() {
            var userRoles = vm.userRoles;
            for (var i = 0; i < userRoles.length; i++) {
                if (userRoles[i].RoleType)
                    vm.roleTypes[i] = userRoles[i].RoleType;
            }
        }

        function _getAllTrainers() {
            trainerService.GetAllTrainers()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postTrainer() {
            trainerService.PostTrainer(vm.trainerModel)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _updateTrainer() {
            vm.trainerModel.id = 21;
            trainerService.UpdateTrainer(vm.trainerModel)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _deleteTrainer() {
            trainerService.DeleteTrainer(20)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }
    }
})();