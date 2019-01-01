(function () {
    'use strict';

    angular.module(AppName).controller("testController", TestController);
    TestController.$inject = ["$scope", "apiService"];

    function TestController($scope, apiService) {
        var vm = this;
        vm.stopNav = false;
        vm.clickStopNav = _clickStopNav;


        function _clickStopNav(){
            vm.stopNav = true;
        }

        function getCurrentPosition(){
            gm.info.getCurrentPosition(processPosition, true);

            if(vm.stopNav){

            }else{
                vm.getCurrentPosition();
            }
        }
        console.log("here");
        vm.testThis = gm.info.getVIN();
        vm.vin = 'sadasd';
        // debugger;
        // vm.vin = gm.nav()
        gm.info.getCurrentPosition(processPosition, true);
        // gm.nav.getDestination(success, true);

        function processPosition(destination) {
            console.log(destination);
            console.log("gm info is:", gm.info);

        }

        function _testApi() {
            apiService.RequestResponse("GET", "TEST/API")
                .then(function (data) {}).catch(function (err) {});
        }
    }

})();