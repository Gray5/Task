app.controller('pageCtrl', function ($scope, $rootScope, $http) {
    var pageButton = {
        "backward": true,
        "forward": false
    }
    $scope.pageButton = pageButton;
    $scope.page = params.page;
    function sendData() {
        $http.post("api/Adresses", params).then(function (response) {
            pageButton["forward"] = false;
            pageButton["backward"] = false;
            if (response.data.TotalPageCount < params.page) {
                params.page = response.data.TotalPageCount;
                sendData();
                return;
            }
            if (response.data.TotalPageCount == params.page)
                pageButton["forward"] = true;
            if (params.page == 1)
                pageButton["backward"] = true;
            $scope.page = params.page;
            $scope.pageButton = pageButton;
            $rootScope.records = response.data;
        });
    }
    $scope.pageNext = function () {
        params.page++;
        sendData();
    }
    $scope.pagePrevious = function () {
        params.page--;
        sendData();
    }
    sendData();
});