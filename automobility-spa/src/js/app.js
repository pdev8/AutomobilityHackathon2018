// Your code goes here

angular.module('ngi', [])
  .controller('HelloWorldCtrl', ['$scope', '$timeout', function($scope, $timeout){
    $timeout(function(){
      console.log("here");
      $scope.vin = gm.info.getVIN();
      $scope.test = 'testing';
    }, 300);



    
  }]);
