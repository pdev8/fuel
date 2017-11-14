(function () {
    "use strict";

    angular.module(AppName).factory("clientService", ClientService);
    ClientService.$inject = ["$http", "$q"];

    function ClientService($http, $q) {

        var srv = {
            CreateClient : _createClient,
            EditClient : _editClient,
            DeleteClient : _deleteClient,
            GetClientById : _getClientById,
            GetAllClients : _getAllClients
        };

        return srv;
    }

    function _createClient(clientModel) {
        $http.post("/api/clients", clientModel, { withCredentials: true })
            .then(function(response) {
                return response.data;
            }).catch(function (err) {
                return $q.reject(err);
            });
    }

    function _editClient(clientModel) {
        $http.put("/api/clients", clientModel, { withCredentials: true })
            .then(function(response) {
                return response.data;
            }).catch(function(err) {
                return $q.reject(err);
            });

    }

    function _deleteClient(id) {
        $http.delete("/api/clients/" + id, { withCredentials: true })
            .then(function(response) {
                return response.data;
            }).catch(function(err) {
                return $q.reject(err);
            });
    }

    function _getClientById(id) {
        $http.get("/api/clients/" + id, { withCredentials: true })
            .then(function(response) {
                return response.data;
            }).catch(function(err) {
                return $q.reject(err);
            });

    }

    function _getAllClients() {
        $http.get("/api/clients", { withCredentials: true })
            .then(function(response) {
                return response.data;
            }).catch(function(err) {
                return $q.reject(err);
            });
    }


})();