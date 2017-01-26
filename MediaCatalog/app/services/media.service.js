//media.service.js
(function () {
    'use strict';
    var module = angular.module('app.service').factory('MediaService', mediaService);

    function mediaService() {

        return {
            getAllMedia: getAllMedia
        };

        function getAllMedia() {
            return [
                {
                    id: 1,
                    name: 'Test 1'
                },
                {
                    id: 2,
                    name: 'Test 2'
                }
            ];
        }
    }
  
}
)();