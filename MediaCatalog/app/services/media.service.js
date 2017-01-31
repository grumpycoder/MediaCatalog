//media.service.js
(function () {
    'use strict';
    var module = angular.module('app.service').factory('MediaService', mediaService);

    function mediaService($http) {

        return {
            getMedia: getMedia,
            getAllMedia: getAllMedia,
            save: save
        };

        function getMedia(id) {
            return $http.get('api/media/' + id).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function getAllMedia(searchModel) {
            return $http.get('api/media', { params: searchModel }).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function save(media) {
            return $http.put('api/media', media).then(function (r) {
                return r.data; 
            }).catch(function (err) {
                return err.message;
            });
        }

    }

}
)();