//app.module.js
(function () {
    'use strict';

    var module = angular.module('app',
        [
            'AdalAngular',
            'ngStorage',
            'app.directives',
            'shared.components',
            'ui.bootstrap',
            'smart-table',
            'cp.ngConfirm'
        ]).config(['$httpProvider', 'adalAuthenticationServiceProvider',
            //function ($localStorageProvider, $httpProvider, adalProvider) {
            function ($httpProvider, adalProvider) {
                //$localStorageProvider.setKeyPrefix('mc-');
                //$httpProvider.interceptors.push('AuthenticationInterceptor');

                var endpoints = {
                    "https://localhost:44362/api": "01951663-dec1-4a5b-b4b5-1cef72f610e5"
                };

                //var endpoints = {}

                adalProvider.init(
                    {
                        //instance: 'https://login.microsoftonline.com/',
                        tenant: 'ffb63644-2219-46e0-9edd-cad35ce33520',
                        clientId: '01951663-dec1-4a5b-b4b5-1cef72f610e5',
                        extraQueryParameter: 'nux=1',
                        //endpoints: endpoints
                        cacheLocation: 'localStorage', // enable this for IE, as sessionStorage does not work for localhost.  
                        // Also, token acquisition for the To Go API will fail in IE when running on localhost, due to IE security restrictions.
                    },
                    $httpProvider
                );

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