'use strict';

app.controller('localeCtrl', function indexCtrl($scope, $location, filterFilter, gettextCatalog) {

    $scope.languages = {
        current: gettextCatalog.currentLanguage,
        available: {
            'ru_RU': 'Russian',
            'en': 'English'
        }
    };
    $scope.$watch('languages.current', function (lang) {
        if (!lang) {
            return;
        }

        gettextCatalog.setCurrentLanguage(lang);
    });

});
