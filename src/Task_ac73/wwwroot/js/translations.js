angular.module('gettext').run(['gettextCatalog', function (gettextCatalog) {
/* jshint -W100 */
    gettextCatalog.setStrings('ru_RU', {"Building":"Дом","Change language":"Изменить язык","Country":"Страна","Date":"Дата","Postcode":"Индекс","Street":"Улица","Town":"Город"});
/* jshint +W100 */
}]);