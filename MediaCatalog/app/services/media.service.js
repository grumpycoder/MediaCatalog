//media.service.js
(function () {
    'use strict';
    var module = angular.module('app.service').factory('MediaService', mediaService);

    function mediaService($http) {

        return {
            getAllMedia: getAllMedia
        };

        function getAllMedia(searchModel) {
            console.log('service searchModel', searchModel);

            return $http.get('api/media/search/', { params: searchModel }).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }
    }

}
)();