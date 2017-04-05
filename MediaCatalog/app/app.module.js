//app.module.js
(function () {
    'use strict';

    var module = angular.module('app',
    [
        'ngStorage',
        'app.directives',
        'shared.components',
        'ui.bootstrap',
        'smart-table',
        'cp.ngConfirm'
    ]);
})();