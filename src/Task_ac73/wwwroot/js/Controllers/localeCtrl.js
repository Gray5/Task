'use strict';

app.controller('localeCtrl', function localeCtrl($scope, $location, gettextCatalog) {

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
