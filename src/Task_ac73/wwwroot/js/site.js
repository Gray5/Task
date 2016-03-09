angular.module('myApp', ['gettext']);

var params = {
    count: 10,
    page: 1,
    sortColumn: 0,
    filters: filter
};
var filter = {
    country: "",
    town: "",
    street: "",
    building: "",
    postcode: "",
    date: ""
}
var app = angular.module('adressAp', []);
app.value("locale", $RussianPack);
app.value("language", "russian");
app.controller('adresCtrl', function ($scope, $http) {
    $http.post("api/Adresses", params)
    .then(function (response) {
        $scope.records = response.data;
    });
});