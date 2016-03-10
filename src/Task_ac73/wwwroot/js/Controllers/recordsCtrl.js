app.controller('recordsCtrl', function ($scope,$rootScope, $http) {
    
    var sortIcons = {
        "notSorted": "glyphicon-sort",
        "asc": "glyphicon-sort-by-attributes",
        "desc": "glyphicon-sort-by-attributes-alt"
    }
    var buttonsState = [sortIcons["notSorted"], sortIcons["notSorted"], sortIcons["notSorted"], sortIcons["notSorted"], sortIcons["notSorted"], sortIcons["notSorted"]];
    $scope.buttonState = buttonsState;
    function sendData() {
        $http.post("api/Adresses", params).then(function (response) {
            $rootScope.records = response.data;
        });
    }
    $scope.change = function () {
        params['filters']['country'] = $scope.country ? $scope.country : "";
        params['filters']['town'] = $scope.town ? $scope.town : "";
        params['filters']['street'] = $scope.street ? $scope.street : "";
        params['filters']['building'] = $scope.building ? $scope.building : "";
        params['filters']['postcode'] = $scope.postcode ? $scope.postcode : "";
        params['filters']['date'] = $scope.date ? $scope.date : "";
        sendData();
    };
    $scope.sort = function (event) {
        if (params.sortColumn == event.target.id) {
            if (params.sortDirection) {
                params.sortDirection = false;
                buttonsState[event.target.id] = sortIcons["desc"];
            } else {
                params.sortColumn = -1;
                buttonsState[event.target.id] = sortIcons["notSorted"];
            }
        } else {
            params.sortDirection = true;
            params.sortColumn = event.target.id;
            buttonsState.forEach(function (item, i, arr) {
                arr[i] = sortIcons["notSorted"];
            });
            buttonsState[event.target.id] = sortIcons["asc"];
        }
        sendData();
    };
    sendData();
});