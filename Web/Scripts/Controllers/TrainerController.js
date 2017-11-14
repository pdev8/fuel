(function() {
    angular.module("fuelApp").controller("trainerController", TrainerController);
    TrainerController.$inject = ["$scope", "trainerService"];

    function TrainerController($scope, trainerService) {
        var vm = this;

        vm.getAllTrainers = _getAllTrainers;
        vm.postTrainer = _postTrainer;
        vm.updateTrainer = _updateTrainer;
        vm.deleteTrainer = _deleteTrainer;

        vm.trainerModel = {
            bio: "",
            userProfileId: 0
        };

        vm.$onInit = _init;

        function _init() {
            console.log("trainerController connected...");
            vm.getAllTrainers();
            //vm.postTrainer();
        }

        function _getAllTrainers() {
            trainerService.GetAllTrainers()
                .then(function(data) {
                    console.log(data);
                })
                .catch(function(err) {
                    console.log(err);
                });
        }

        function _postTrainer() {
            trainerService.PostTrainer(vm.trainerModel)
                .then(function(data) {
                    console.log(data);
                })
                .catch(function(err) {
                    console.log(err);
                });
        }

        function _updateTrainer() {
            vm.trainerModel.id = 21;
            trainerService.UpdateTrainer(vm.trainerModel)
                .then(function(data) {
                    console.log(data);
                })
                .catch(function(err) {
                    console.log(err);
                });
        }

        function _deleteTrainer() {
            trainerService.DeleteTrainer(20)
                .then(function(data) {
                    console.log(data);
                })
                .catch(function(err) {
                    console.log(err);
                });
        }
    }
})();