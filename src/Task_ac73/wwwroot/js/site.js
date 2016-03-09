'use strict';

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
var app = angular.module('adressAp', ['gettext']);
app.run(function (gettextCatalog) {
    gettextCatalog.currentLanguage = 'ru_RU';
});