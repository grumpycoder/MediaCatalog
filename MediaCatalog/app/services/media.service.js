//media.service.js
(function () {
    'use strict';
    var module = angular.module('app.service').factory('MediaService', mediaService);

    function mediaService($http) {

        return {
            getAllMedia: getAllMedia
        };

        function getAllMedia() {
            return $http.get('api/media').then(function (r) {
                console.log('r', r);
                return r.data;
            }).catch(function(err) {
                console.log(err.message);
            });
        }
    }
  
}
)();