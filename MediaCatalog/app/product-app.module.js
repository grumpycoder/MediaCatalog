//product-app.module.js
(function() {
    'use strict';

    var module = angular.module('app',
    [
        'app.services',
        'app.directives',
        'shared.components',
        'ngComponentRouter',
        'ui.bootstrap',
        'smart-table'
    ]);

    //module.config(function () {//$locationProvider.html5Mode(true); });

    module.component('libraryApp',
    {
        templateUrl: '/app/product-app.component.html',
        $routeConfig: [
            { path: '/', name: 'List', component: 'list', useAsDefault: true }
        ]
    });

    module.value('$routerRootComponent', 'libraryApp');

    module.config(function (stConfig) {
        stConfig.search.delay = 2000;
    });

})();