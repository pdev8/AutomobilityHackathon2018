(function () {
    'use strict';

    angular.module(AppName).controller("dummyDirectionController", DummyDirectionController);
    DummyDirectionController.$inject = ["$scope", "$timeout", "apiService"];

    function DummyDirectionController($scope, $timeout, apiService) {
        var vm = this;
        vm.stopNav = false;
        vm.clickStopNav = _clickStopNav;
        vm.getRouteRecursive = _getRouteRecursive;
        vm.getRoutes = _getRoutes
        vm.getDestionation = _getDestination;
        vm.getDirectionModel = {
            currentLocation: {},
            destination: {}
        }


        function _clickStopNav(){
            vm.stopNav = true;
        }
        // vm.getCurrentPositionFunction();
        vm.getDestionation();
        vm.getRouteRecursive();
        function _getRouteRecursive(){
            // gm.info.getCurrentPosition(processPosition, true);
            // vm.getRoutes(vm.getDirectionModel);
            if(vm.stopNav){
                console.log("got here23");
            }else{
                if(vm.getDirectionModel.currentLocation === vm.getDirectionModel.destination){

                }else{
                    console.log("got here2");
                    vm.stopNav = true;
                    $timeout(vm.getRouteRecursive(), 20000);
                }
            }
        }
        function _getDestination(){
            apiService.RequestResponse("GET", "TEST/API")
            .then(function (data) {
                vm.getDirectionModel.destination = data;
            }).catch(function (err) {

            });
        }
        function _getRoutes(model){
            apiService.RequestResponse("GET", "TEST/API")
            .then(function (data) {
                vm.routes = data;
            }).catch(function (err) {
                
            });
        }
        function processPosition(currentLocation) {
            vm.getDirectionModel.currentLocation = currentLocation;
        }
    }

})();