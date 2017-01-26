//media-list.component.js
(function () {
    'use strict';

    var module = angular.module('media');

    function controller(service) {
        console.log('list component activated');

        var $ctrl = this;

        $ctrl.$onInit = function () {
            $ctrl.search();
        }

        $ctrl.search = function() {
            service.getAllMedia().then(function (r) {
                $ctrl.model = r;
            });
        }
    }

    module.component('list',
    {
        templateUrl: 'app/media/media-list.component.html',
        controller: ['MediaService', controller]
    });
}
)();