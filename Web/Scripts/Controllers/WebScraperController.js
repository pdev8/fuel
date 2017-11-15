(function () {
    angular.module(AppName).controller("webScraperController", WebScraperController);
    WebScraperController.$inject = ["$scope", "webScraperService"];

    function WebScraperController($scope, webScraperService) {
        var vm = this;

        vm.model = {
            rating: 0,
            url: ""
        }

        vm.scrape = _scrape;
        vm.title = "";
        vm.urlLinks = {
            Article_1: "http://www.cnn.com/2017/11/14/politics/roy-moore/index.html",
            Article_2: "http://www.cnn.com/2017/11/11/politics/john-mccain-donald-trump-russia/index.html",
            Article_3: "http://www.cnn.com/2017/11/14/africa/zimbabwe-military-chief-treasonable-conduct/index.html",
            Article_4: "http://www.cnn.com/2017/11/14/health/scientists-warn-humanity/index.html"
        }

        vm.$onInit = _init;

        function _init() {
        }

        function _scrape() {
            console.log(vm.model);
            webScraperService.GetRating(vm.model)
                .then(function (data) {
                    vm.title = data;
                    console.log(data);
                })
                .catch(function (err) {
                    console.log(err);
                });
        }
    }
})();