(function () {
    angular.module(AppName).controller("userRoleController", UserRoleController);
    UserRoleController.$inject = ["$scope", "userRoleService"];


    function UserRoleController($scope, userRoleService) {
        var vm = this;

        vm.selectedRole;

        vm.userRoles = [];
        vm.roleTypes = [];
        vm.getUserRoles = _getUserRoles;
        vm.getRoleTypes = _getRoleTypes;

        vm.$onInit = _init;

        function _init() {
            _getUserRoles();
        }

        function _getUserRoles() {
            userRoleService.GetAllUserRoles()
                .then(function(data) {
                    vm.userRoles = data.Items;
                    _getRoleTypes();
                })
                .catch(function(err) {
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
    }
})();