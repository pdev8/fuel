(function () {
    angular.module(AppName).controller("loginController", LoginController);

    LoginController.$inject = ["$scope"];

    function LoginController($scope) {
        var vm = this;

        vm.login = _login;

        vm.$onInit = _init;

        function _init() {
            console.log("linked");
        }

        function _login() {
            console.log("logged in");
        }
    }
})();