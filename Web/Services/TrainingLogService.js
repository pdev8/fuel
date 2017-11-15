(function () {
    "use strict";

    angular.module(AppName).factory("trainingLogService", TrainingLogService);
    TrainingLogService.$inject = ["$http", "$q"];

    function TrainingLogService($http, $q) {

        var srv = {
            CreateTrainingLog: _createTrainingLog,
            EditTrainingLogByWeek: _editTrainingLogByWeek,
            DeleteTrainingLogByWeek: _deleteTrainingLogByWeek,
            GetTrainingLogByWeek: _getTrainingLogByWeek
        };

        return srv;

        function _createTrainingLog(trainingLogModel) {
            return $http.post("/api/trainingLogs", trainingLogModel, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                });
        }

        function _editTrainingLogByWeek(trainingLogModel) {
            return $http.put("/api/trainingLogs/" + trainingLogModel.Week, trainingLogModel, { withCredentials: true })
                .then(function (response) {
                    console.log('in JS service, trainingLogModel: ', trainingLogModel);
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                });
        }

        function _deleteTrainingLogByWeek(trainingLogModel) {
            return $http.delete("/api/trainingLogs/" + trainingLogModel.Week, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                });
        }

        function _getTrainingLogByWeek(week) {
            console.log(week);
            return $http.get("/api/TrainingLogs/" + week, { withCredentials: true })
                .then(function (response) {
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                });
        }


    }


})();