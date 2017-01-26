//media-list.component.js
(function () {
    'use strict';

    var module = angular.module('media');
    
    function controller(service) {
        var $ctrl = this;

        console.log('list component activated');

        $ctrl.model = service.getAllMedia();
        console.log('data', $ctrl.model);
    }

    module.component('list',
    {
        templateUrl: 'app/media/media-list.component.html',
        controller: ['MediaService', controller]
    });
}
)();