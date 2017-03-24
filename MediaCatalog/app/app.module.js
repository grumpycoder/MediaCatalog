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
        ]).config(['$localStorageProvider', '$httpProvider',
            function ($localStorageProvider, $httpProvider) {
                $localStorageProvider.setKeyPrefix('mc-');
                $httpProvider.interceptors.push('AuthenticationInterceptor');
            }
        ]);


    module.factory('AuthenticationInterceptor',
        ['$localStorage', '$window', function ($localStorage, $window) {
            var service = this;
            service.request = function (config) {
                config.headers = config.headers || {};
                if ($localStorage.currentUser) {
                    config.headers.Authorization = 'Bearer ' + $localStorage.currentUser.token;
                }
                return config;
            };

            service.responseError = function (response) {
                console.log('response error', response);
                if (response.status === 401 || response.status === 403) {
                    $window.location = '/account/login';
                }
                return $q.reject(response);
            };

            return service;
        }]);

})();