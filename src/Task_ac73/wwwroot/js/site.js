'use strict';

var app = angular.module('adressAp', ['gettext']);
app.run(function (gettextCatalog) {
    gettextCatalog.currentLanguage = 'ru_RU';
});
var records;
var params = {
    count: 10,
    page: 1,
    sortColumn: -1,
    sortDirection: true,
    filters: {
        country: "",
        town: "",
        street: "",
        building: "",
        postcode: "",
        date: ""
    }
};