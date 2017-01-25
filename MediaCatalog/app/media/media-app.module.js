//app.module.js
(function () {
    'use strict';

    var module = angular.module('media', ['ngComponentRouter']);

    //module.config(function () {//$locationProvider.html5Mode(true); });

    module.component('mediaApp',
    {
        templateUrl: '/app/media/media-app.component.html',
        $routeConfig: [
            { path: '/', name: 'List', component: 'list', useAsDefault: true }
            //{ path: '/:id', name: 'Details', component: 'detail' },
            //{ path: '/edit/:id', name: 'Edit', component: 'edit' },
            //{ path: '/create', name: 'Create', component: 'create' }
        ]
    });

    module.value('$routerRootComponent', 'mediaApp');

}
)();