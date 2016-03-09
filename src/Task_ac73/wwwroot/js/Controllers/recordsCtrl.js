app.controller('recordsCtrl', function ($scope, $http) {
    $http.post("api/Adresses", params)
    .then(function (response) {
        $scope.records = response.data;
    });
});