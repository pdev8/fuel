(function () {
    angular.module(AppName).controller("clientController", ClientController);
    ClientController.$inject = ["$scope", "clientService"];

    function ClientController($scope, clientService) {

        var vm = this;

        vm.getAllClients = _getAllClients;
        vm.getClientById = _getClientById;
        vm.postClient = _postClient;
        vm.updateClient = _updateClient;
        vm.deleteClient = _deleteClient;

        vm.model = {};

        vm.$onInit = _init;

        function _init() {
            console.log("Client controller loading");
        }

        function _getAllClients() {
            clientService.GetAllClients()
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _getClientById() {
            clientService.GetClientById()
            .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postClient() {
            clientService.CreateClient()
            .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _updateClient() {
            clientService.EditClient()
            .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _deleteClient() {
            clientService.DeleteClient()
            .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }
        
    }
})();