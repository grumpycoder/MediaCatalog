//media-list.component.js
(function () {
    'use strict';

    var module = angular.module('media');

    function controller() {
        console.log('list component activated');
    }

    module.component('list',
    {
        templateUrl: 'app/media/media-list.component.html',
        controller: controller
    });
}
)();