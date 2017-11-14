(function () {
    angular.module("fuelApp").factory("trainerService", TrainerService);
    TrainerService.$inject = ["$http", "$q"];

    function TrainerService($http, $q) {
        //var apiRoot = "http://localhost:3024";

        var srv = {
            GetAllTrainers: _getAllTrainers,
            GetTrainerById: _getTrainerById,
            PostTrainer: _postTrainer,
            UpdateTrainer: _updateTrainer,
            DeleteTrainer: _deleteTrainer
        };

        return srv;

        function _getAllTrainers() {
            var defer = $q.defer();

            $http.get("/api/Trainers", { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }

        function _getTrainerById() {
            var defer = $q.defer();

            $http.get("/api/Trainers", { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }

        function _postTrainer(trainerModel) {
            var defer = $q.defer();

            $http.post("/api/Trainers", trainerModel, { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }

        function _updateTrainer(trainerModel) {
            var defer = $q.defer();

            $http.put("/api/Trainers/" + trainerModel.id, trainerModel, { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }

        function _deleteTrainer(id) {
            var defer = $q.defer();

            $http.delete("/api/Trainers/" + id, { withCredentials: true })
                .then(function (response) {
                    defer.resolve(response.data);
                })
                .catch(function (err) {
                    defer.reject(err);
                });

            return defer.promise;
        }
    }
})();