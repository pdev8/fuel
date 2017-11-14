(function () {
    angular.module(AppName).controller("loginController", LoginController);

    LoginController.$inject = ["$scope"];

    function LoginController($scope) {
        var vm = this;

        vm.loginAsTrainer = _loginAsTrainer;

        vm.$onInit = _init;

        function _init() {
            console.log("linked");
        }

        function _loginAsTrainer() {
            console.log("logged in");
            location.href = "/Home/Contact";
        }
    }
})();