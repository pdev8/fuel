(function () {
    angular.module("fuelApp").controller("trainerController", TrainerController);
    TrainerController.$inject = ["$scope", "trainerService", "userRoleService", "userProfileService"];

    function TrainerController($scope, trainerService, userRoleService, userProfileService) {
        var vm = this;

        vm.getAllTrainers = _getAllTrainers;
        vm.postTrainer = _postTrainer;
        vm.updateTrainer = _updateTrainer;
        vm.deleteTrainer = _deleteTrainer;

        vm.trainerModel = {
            id: 0,
            bio: "",
            userProfileId: 0,
            firstName: "",
            lastName: "",
            email: "",
            gender: ""
        };

        vm.genders = ["Male", "Female"];

        vm.trainers = [];
        vm.userRoles = [];
        vm.roleTypes = [];
        vm.getUserRoles = _getUserRoles;
        vm.getRoleTypes = _getRoleTypes;
        vm.editTrainer = _editTrainer;

        vm.$onInit = _init;

        function _init() {
            //console.log("trainerController connected...");
            //vm.getAllTrainers();
            //vm.postTrainer();
            //_getUserRoles();
        }

        function _getUserRoles() {
            userRoleService.GetAllUserRoles()
                .then(function (data) {
                    vm.userRoles = data.Items;
                    _getRoleTypes();

                    //console.log(vm.userRoles);
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
                    vm.trainers = data.Items;
                    vm.trainerModel.id = data.Items.Id;
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postTrainer() {
            console.log(vm.trainerModel);
            trainerService.PostTrainer(vm.trainerModel)
                .then(function (data) {
                    console.log(data);
                    vm.trainerModel = {};
                    _getAllTrainers();
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _updateTrainer() {
            //vm.trainerModel.id = 21;
            trainerService.UpdateTrainer(vm.trainerModel)
                .then(function (data) {
                    console.log(data);
                    vm.trainerModel = {};
                    _getAllTrainers();
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _deleteTrainer(trainer) {
            trainerService.DeleteTrainer(trainer.Id)
                .then(function (data) {
                    var index = vm.trainers.indexOf(trainer);
                    vm.trainers.splice(index, 1);
                    _getAllTrainers();
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _editTrainer(trainer) {
            vm.trainerModel = {
                id: trainer.Id,
                bio: trainer.Bio,
                userProfileId: 0,
                firstName: trainer.FirstName,
                lastName: trainer.LastName,
                email: trainer.Email,
                gender: trainer.Gender
            };
        }
    }
})();