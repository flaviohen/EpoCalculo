var app = angular.module('myApp', []);
app.controller('customersCtrl', function ($scope, $http) {
    $http.get("https://copadosfilmes.azurewebsites.net/api/filmes")
  .then(function (response) { $scope.filmes = response.data; });
});