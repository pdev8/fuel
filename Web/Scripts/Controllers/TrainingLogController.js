(function () {
    angular.module(AppName).controller("trainingLogController", TrainingLogController);
    TrainingLogController.$inject = ["$scope", "trainingLogService"];

    function TrainingLogController($scope, trainingLogService) {

        var vm = this;

        vm.deleteTrainingLogByWeek = _deleteTrainingLogByWeek;

        vm.submit = _submit;
        vm.edit = _updateTrainingLogByWeek;
        vm.getByWeek = _getTrainingLogByWeek;

        vm.arrayWeeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
        
        vm.showNewRightDiv = false;

        vm.model = {};
        vm.model.SquatMax = 225;
        vm.model.BenchMax = 135;
        vm.model.DeadliftMax = 315;

        vm.$onInit = _init;

        function _init() {
            console.log("Training log controller loaded");
        }

        function _submit() {

            // call function to calculate Program numbers from TM numbers
            _calculateProgram();

            // post to training log table
            _postTrainingLog();

            // show right div with log
            vm.showNewRightDiv = true;
            
            // clear form
            vm.model = {};
        }
        
        // take TM numbers and calculate Program numbers
        function _calculateProgram() {

            // calculate the percentage for this week's programming, as determined by vm.selectedWeek
            var multiplier = 1;

            switch (vm.model.Week) {
                case 1:
                    multiplier = 0.60;
                    break;
                case 2:
                    multiplier = 0.65;
                    break;
                case 3:
                    multiplier = 0.75;
                    break;
                case 4:
                    multiplier = 0.45;
                    break;
                case 5:
                    multiplier = 0.60;
                    break;
                case 6:
                    multiplier = 0.65;
                    break;
                case 7:
                    multiplier = 0.70;
                    break;
                case 8:
                    multiplier = 0.45;
                    break;
                case 9:
                    multiplier = 0.75;
                    break;
                case 10:
                    multiplier = 0.80;
                    break;
                case 11:
                    multiplier = 0.825;
                    break;
                case 12:
                    multiplier = 0.85;
                    break;
            }

            // append to vm.model as .squatProgram .benchProgram .deadliftProgram
            // model will need .Week .SquatMax .BenchMax .DeadliftMax .SquatProgram .BenchProgram .DeadliftProgram
            vm.model.SquatProgram = Math.round(multiplier * vm.model.SquatMax);
            vm.squatProgram = vm.model.SquatProgram;

            vm.model.BenchProgram = Math.round(multiplier * vm.model.BenchMax);
            vm.benchProgram = vm.model.BenchProgram;

            vm.model.DeadliftProgram = Math.round(multiplier * vm.model.DeadliftMax);
            vm.deadliftProgram = vm.model.DeadliftProgram;

        }

        function _getTrainingLogByWeek() {
            console.log('in controller js: ', vm.model.Week);
            trainingLogService.GetTrainingLogByWeek(vm.model.Week)
                .then(function (data) {
                    console.log(data.Item);
                    // return program object of Id, Week, SquatMax, etc.
                    vm.model = data.Item;
                    console.log(vm.model);
                    //vm.squatProgram = vm.model.SquatProgram;

                    //vm.benchProgram = vm.model.BenchProgram;

                    //vm.deadliftProgram = vm.model.DeadliftProgram;

                    _calculateProgram();

                    //vm.showGetRightDiv = true;
                    vm.showNewRightDiv = true;
                })
                .catch(function (err) {
                    console.log(err);
                });
        }

        function _postTrainingLog() {
            trainingLogService.CreateTrainingLog(vm.model)
                .then(function (data) {
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _updateTrainingLogByWeek() {
            trainingLogService.EditTrainingLogByWeek(vm.model)
                .then(function (data) {
                    console.log('edit button clicked');

                    _calculateProgram();
                    //vm.showGetRightDiv = true;
                    vm.showNewRightDiv = true;
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });

        }

        function _deleteTrainingLogByWeek() {
            trainingLogService.DeleteTrainingLogByWeek(vm.model)
                .then(function (data) {
                    console.log(data);
                    vm.model = {};
                    vm.showNewRightDiv = false;
                    //vm.showGetRightDiv = false;

                })
                .catch(function (err) {
                    console.log(err);
                });

        }

    }

})();