(function () {
    'use strict';

    angular.module(AppName).controller("testController", TestController);
    TestController.$inject = ["$scope", "apiService"];

    function TestController($scope, apiService) {
        var vm = this;
        vm.showprofileSettings = _showProfileSettings;
        vm.showProfileSelect = _showProfileSelect;
        vm.showRouteDirection = _showRouteDirection;
        vm.showRouteSelect = _showRouteSelect;
        vm.showLoader = _showLoader;
        vm.showDurationSelect = _showDuratationSelect;
        vm.resetState = _resetState;

        vm.profiles = [{
                Name: "John",
                Color: "blue",
                img: "assets/images/users/1.png"
            },
            {
                Name: "Mary",
                Color: "Red",
                img: "assets/images/users/2.png"
            },
            {
                Name: "Guest",
                Color: "Grey",
                img: "assets/images/users/3.png"
            }
        ];

        vm.state = {
            profileSelect: true,
            profileSettings: false,
            routeSelect: false,
            routeDirection: false,
            liveParking: false,
            profileCreate: false,
            meter: false,
            loader: false,
            parkerShow: true,
            durationSelect: false

        };


        function _showLoader() {
            vm.resetState();
            vm.state.loader = true;
        }

        function _showDuratationSelect() {
            vm.resetState();
            vm.state.durationSelect = true;
        }

        function _showProfileSettings() {
            vm.resetState();
            vm.state.profileSettings = true;
        }

        function _showProfileSelect() {
            console.log('clicked');
            vm.resetState();
            vm.state.profileSelect = true;
        }

        function _showRouteSelect() {
            vm.resetState();
            vm.state.routeSelect = true;
        }

        function _showRouteDirection() {
            vm.resetState();
            vm.state.routeDirection = true;
            vm.state.parkerShow = false;
        }

        function _resetState() {
            vm.state.profileCreate = false;
            vm.state.profileSettings = false;
            vm.state.routeSelect = false;
            vm.state.profileSelect = false;
            vm.state.routeDirection = false;
            vm.state.liveParking = false;
            vm.state.profileCreate = false;
            vm.state.meter = false;
            vm.state.loader = false;
            vm.state.durationSelect = false;

        }

    }

})();